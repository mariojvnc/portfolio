package at.htldonaustadt.jovanovic.demo;

import java.util.HashMap;

public interface DataAnalyzedEvent {
    void newFile(Object sender, HashMap<Integer, Integer> wordlengthToCount);
}
