package at.htldonaustadt.jovanovic.demo;

import java.util.HashMap;

public class DataCombiner implements DataAnalyzedEvent {
    private HashMap<Integer, Integer> wordLengthToCount_combined;

    public DataCombiner() {
        wordLengthToCount_combined = new HashMap<>();
    }

    @Override
    public void newFile(Object sender, HashMap<Integer, Integer> wordlengthToCount) {
        // we got some new data :)
        // now, let´s combine our given data with the one we already have

        wordlengthToCount.forEach( (key, value) -> {
            // Go through every single KeyValue-pair
            if(! wordLengthToCount_combined.containsKey(key)){
                // not matching keys
                wordLengthToCount_combined.put(key, value);
            } else {
                // matching keys
                wordLengthToCount_combined.put(key, wordLengthToCount_combined.get(key) + value);
            }
        });

    }

    @Override
    public String toString() {
        StringBuilder builder = new StringBuilder();

        wordLengthToCount_combined.forEach( (key, value) -> {
            builder.append(key).append(" | ").append(value).append("\n");
        });

        return builder.toString();
    }
}
