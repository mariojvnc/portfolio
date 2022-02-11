package JavaLernen;

import javax.sound.midi.SysexMessage;
import java.nio.channels.ScatteringByteChannel;
import java.util.Arrays;
import java.util.OptionalDouble;
import java.util.Random;
import java.util.Scanner;

public class Main {

    private static Random rnd = new Random();
    public static int[] GenerateNumbers(int count){
        int[]numbers = new int[count];

        for (int i = 0; i < count; i++){
            numbers[i] = rnd.nextInt(100) + 1;
        }

        return numbers;
    }

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        //region Create Random Numbers
        /*System.out.println("Wie viele Zahlen möchtest du generieren? ");

        int count = sc.nextInt();

        if(count < 0){
            System.out.println(count +  " ist eine ungültige Anzahl");
            System.exit(1);
        }

        int[]numbers = GenerateNumbers(count);
        for(int number : numbers){
            System.out.println(number);
        }
        OptionalDouble average = Arrays.stream(numbers).average();

        System.out.println("Der Durchschnitt ist " +Math.round(average.getAsDouble()) +".");*/
        //endregion

        //region Person example
        System.out.println("First name: ");
        String firstname = sc.nextLine();
        System.out.println("Last name: ");
        String lastname = sc.nextLine();
        System.out.println("Age: ");
        int age = sc.nextInt();

        System.out.println("Gender: ");
        String genderStringValue = sc.nextLine();
        Gender gender = null;

        try{
            gender = Gender.valueOf(genderStringValue);
        }
        catch (Exception ex){
            System.out.println(ex);
        }


        Person person = new Person(firstname, lastname, age, gender);
        System.out.println(person.toString());

        boolean wantToRename = false;
        System.out.println("Do you want to rename " + person.GenderPrefix + " lastname ?");
        String answer = sc.nextLine();
        answer = answer.toLowerCase();
        if(answer == "ja"){
            wantToRename = true;
        }

        if (wantToRename) {
            person.Rename("Jovanovic");
        }
        System.out.println(person.toString());
        //endregion
    }
}
