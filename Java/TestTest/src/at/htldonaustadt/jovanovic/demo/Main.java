package at.htldonaustadt.jovanovic.demo;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        try(Scanner scanner = new Scanner("src/at/htldonaustadt/input.txt")){
            String content = Files.readString(Path.of("src/at/htldonaustadt/input.txt")).replace("test", "TESTNEU");
            System.out.println(content);
        } catch (IOException e){
            e.printStackTrace();
        }
    }
}
