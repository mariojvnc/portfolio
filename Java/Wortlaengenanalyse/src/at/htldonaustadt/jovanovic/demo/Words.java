package at.htldonaustadt.jovanovic.demo;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.HashMap;

public class Words implements Runnable{
    private String filename;
    private HashMap<Integer, Integer> wordLengthToCount;

    public Words(String filename){
        this.filename = filename;
        wordLengthToCount = new HashMap<Integer , Integer>();
    }

    public String getContent(){
        String content = "";
        try {
            content = new String (Files.readString( Paths.get(filename)))
                    .replaceAll("[^a-zA-Z0-9]", "")
                    .replaceAll("[-:.+^]*", "");
        }
        catch (IOException e){
            e.printStackTrace();
        }
        return content;
    }

    public void fill_wordLengthToCount(){
        String content = getContent();
        // fill HashMap
        String [] parts = content.split(" ");
        for(String word : parts){
            int wordLength = word.length();
            if( wordLengthToCount.containsKey(wordLength)){
                wordLengthToCount.put(wordLength, wordLengthToCount.get(wordLength) + 1);
            } else {
                wordLengthToCount.put(wordLength, 1);
            }
        }
    }

    @Override
    public void run() {
        fill_wordLengthToCount();
    }
}