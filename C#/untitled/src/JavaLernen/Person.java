package JavaLernen;

public class Person {
    public String FirstName;
    public String LastName;
    public String FullName;
    public int Age;
    private boolean IsRenamed;
    public String OldLastName;
    public Gender _Gender;

    public String GenderPrefix;

    public Person(String firstname, String lastname, int age, Gender gender){
        FirstName = firstname;
        LastName = lastname;
        Age = age;
        FullName = GetFullName();
        _Gender =  gender;
        GenderPrefix = GetPrefix();
    }
    public void Rename(String newLastName){
        OldLastName =
        LastName = newLastName;
        IsRenamed = true;
    }

    private String GetPrefix(){
        if(_Gender == Gender.Male){
            return "His";
        } else{
            return  "Her";
        }
    }

    public String GetFullName(){
        return FirstName + " " + LastName;
    }

    @Override
    public String toString() {
        if(!IsRenamed){
            return FullName + "is" + Age + " years old.";
        }
        else{
            return FullName + "is" + Age + " years old.\n" + FullName + " was renamed. " + GenderPrefix + " old lastname was  "+OldLastName;
        }
    }
}
