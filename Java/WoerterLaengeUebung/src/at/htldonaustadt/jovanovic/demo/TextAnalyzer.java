package at.htldonaustadt.jovanovic.demo;

import javax.xml.crypto.Data;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Scanner;

public class TextAnalyzer implements Runnable{
    private HashMap<Integer, Integer> wordlengthToCount;
    private String path;

    private List<DataAnalyzedEvent> observers;

    public void subscribe(DataAnalyzedEvent o){
        if(o != null)
            observers.add(o);
    }
    public void unsubscribe(DataAnalyzedEvent o){
        observers.remove(o);
    }

    public TextAnalyzer(String path)
    {
        wordlengthToCount = new HashMap();
        observers = new ArrayList<>();
        this.path = path;
    }

    public void load () {

        try (Scanner scanner = new Scanner(new File(path))){
            while(scanner.hasNext()){
                String word = scanner.next();
                word = word.replaceAll("0123456789-_.:,;\\?=!" , "");
                int wordlength = word.length();
                if (wordlength >= 2 && wordlength <= 23) {
                    if (!wordlengthToCount.containsKey(wordlength)) {
                        // Not in HashMap
                        // -> add new length (key) and set count (value) to 0
                        wordlengthToCount.put(wordlength, 1);
                    } else {
                        // Contained in HashMap
                        // -> increase value
                        wordlengthToCount.put(wordlength, wordlengthToCount.get(wordlength) + 1);
                    }
                }
            }
        } catch (FileNotFoundException e){
            e.printStackTrace();
        }


        // File was successfully read!
        // now -> send the data to TextCombiner, so he can combine all data in one
        // how? -> we gonna use Events! :)
        observers.forEach( o-> {
            o.newFile(this, wordlengthToCount);
        });

    }

    @Override
    public void run() {
        load();
    }
}
