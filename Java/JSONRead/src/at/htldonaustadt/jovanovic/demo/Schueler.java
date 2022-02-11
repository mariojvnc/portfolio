package at.htldonaustadt.jovanovic.demo;

import java.time.LocalDate;
import lombok.*;
import lombok.experimental.NonFinal;

@Getter
@AllArgsConstructor
@ToString

public class Schueler {
    private @NonFinal String vorname;
    private @Setter String nachname;
    private LocalDate geburtsdatum;

}
