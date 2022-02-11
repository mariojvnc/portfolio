package at.htldonaustadt.jovanovic.demo;
import org.json.*;

import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.time.LocalDate;

public class Main {

    public static void main(String[] args) throws FileNotFoundException {
        JSONObject klasse = new JSONObject();
        klasse.put("name", "4AHIF");
        klasse.put("anzahl", 20);

        JSONArray schueler = new JSONArray();

        JSONObject schueler1 = new JSONObject(20);
        schueler1.put("vorname", "Mert");
        schueler1.put("nachname", "Ada");
        schueler1.put("geburtsdatum", LocalDate.of(2003, 7, 21));
        schueler.put(schueler1);

        JSONObject schueler2 = new JSONObject(20);
        schueler2.put("vorname", "Schamma");
        schueler2.put("nachname", "Ahmed");
        schueler2.put("geburtsdatum", LocalDate.of(2004, 8, 16));
        schueler.put(schueler2);

        klasse.put("schuler", schueler);

        try(PrintWriter writer = new PrintWriter("klasse.json")){
            writer.println(klasse.toString(2));
        }
    }
}