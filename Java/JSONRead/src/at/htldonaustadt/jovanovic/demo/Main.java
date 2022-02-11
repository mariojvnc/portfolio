package at.htldonaustadt.jovanovic.demo;

import org.json.*;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.InputStream;
import java.time.LocalDate;

public class Main {

    public static void main(String[] args) throws FileNotFoundException {
        InputStream inputstream = new FileInputStream("klasse.json");

        JSONObject root = new JSONObject(new JSONTokener(inputstream));
        System.out.println(root.toString(2));

        Schulklasse klasse = new Schulklasse(
                root.getString("name"),
                root.getInt("anzahl"));

        JSONArray schueler = root.getJSONArray("schueler");

        for (int i = 0;  i< schueler.length(); i++) {
            Object s = schueler.get(i);
            // Einlesen mit Überprüfung des konkreten Typs.
            if ( s instanceof JSONObject ) {
                JSONObject einschueler = (JSONObject) s;

                klasse.add(new Schueler(
                        einschueler.getString("vorname"),
                        einschueler.getString("nachname"),
                        LocalDate.parse(einschueler.getString("geburtstag"))
                ));
            }
        }

        // demo code for lombok
        Schueler s = new Schueler("Thomas","Schlögl", LocalDate.of(1969,2,8));
        System.out.println(s);

        System.out.println(s.getNachname());

        s.setNachname("Mark");
        System.out.println(s.getNachname());


    }
}
