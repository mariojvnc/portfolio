package at.htldonaustadt.jovanovic.demo;

import lombok.*;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;

@Getter
@AllArgsConstructor
@ToString

public class Schulklasse extends ArrayList<Schueler> {
    private @Setter String name;
    private int anzahl;
}
