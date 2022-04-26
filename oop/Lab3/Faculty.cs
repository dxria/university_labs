namespace Lab3;
public class Faculty
{
    private string nameFaculty;
    private int numberofDepartments;
    private int numberofSpecializations;
    private int totalStudents;

    public Faculty()
    {
        nameFaculty = "";
        numberofDepartments = 0;
        numberofSpecializations = 0;
        totalStudents = 0;
    }
    public Faculty(string nameFaculty, int numberofDepartments, int numberofSpecializations, int totalStudents)
    {
        this.nameFaculty = nameFaculty;
        this.numberofDepartments = numberofDepartments;
        this.numberofSpecializations = numberofSpecializations;
        this.totalStudents = totalStudents;
    }
    public string NameFaculty { get { return nameFaculty; } set { nameFaculty = value; } }
    public int NumberofDepartments { get { return numberofDepartments; } set { numberofDepartments = value; } }
    public int NumberofSpecializations { get { return numberofSpecializations; }  set { numberofSpecializations = value; } }
    public int TotalStudents { get { return totalStudents; } set { totalStudents = value; } }

    public void EnterValues()
    {
        Console.Write("Faculty name: ");
        nameFaculty = Console.ReadLine();
        while (nameFaculty == null)
        {
            Console.Write("Wrong! Faculty name has to include symbols.\nFaculty name: ");
            nameFaculty = Console.ReadLine();
        }
        Console.Write("Number of Departures: ");
        while (!int.TryParse(Console.ReadLine(), out numberofDepartments)) //перевірка на правильність вводу
        {
            Console.Write("Number of Departures: ");
        }
        Console.Write("Number of Specializations: ");
        while ((!int.TryParse(Console.ReadLine(), out numberofSpecializations)) || (NumberofDepartments > NumberofSpecializations)) //перевірка на правильність вводу
        {
            Console.Write("Wrong! Number of Specializations has to be bigger or equal to Number of Departments.\nNumber of Specializations: ");
        }
        Console.Write("Total amount of students: ");
        while ((!int.TryParse(Console.ReadLine(), out totalStudents)) || (TotalStudents/200 < NumberofSpecializations))  //перевірка на правильність вводу
        {
            Console.Write("Wrong! For each Specialization no less than 200 students.\nTotal amount of students: ");
        }
    }
    public void OutputValues()
    {
        Console.WriteLine("Faculty name: " + NameFaculty);
        Console.WriteLine("Number of Departments: " + NumberofDepartments);
        Console.WriteLine("Number of Specializations: " + NumberofSpecializations);
        Console.WriteLine("Total amount of Students: " + TotalStudents);
    }
    public void WriteToTXT()
    {
        StreamWriter writeFaculty = new StreamWriter(@"D:\my\c#\Lab3\Faculty_data.txt");
        writeFaculty.WriteLine("------------------------------------------\n" +
                               "Faculty name: " + NameFaculty + "\n" +  
                               "Number of Departments: " + NumberofDepartments + "\n" +
                               "Number of Specializations: " + NumberofSpecializations + "\n" +
                               "Total amount of Students: " + TotalStudents + "\n");
        writeFaculty.Close();
    }
    public void ChangeNumberOf()
    {
        Random rand = new Random();
        Console.WriteLine($"Faculty: {nameFaculty},\n" +
                          $"Current Number of Departments: {NumberofDepartments},\n" +
                          $"Current Number of Specializations: {NumberofSpecializations},\n" +
                          $"Current Total amount of Students: {TotalStudents}");
        Console.WriteLine("Would you like to change current information? (1 for yes)");
        char key = Convert.ToChar(Console.ReadLine());
        if (key == '1')
        {
            Console.WriteLine("Press 1 to change Number of Specializations or Press 2 to change Number of Students");
            key = Convert.ToChar(Console.ReadLine());
            switch (key)
            {
                case '1':
                    Console.Write("Enter Number of Specializations: ");
                    while (!int.TryParse(Console.ReadLine(), out numberofSpecializations) || NumberofSpecializations <= 0) //перевірка на правильність вводу
                    {
                        Console.Write("Wrong! Number of Spesialization has to be more than 0.\nEnter Number of Specializations: ");
                    }
                    NumberofDepartments = NumberofSpecializations;
                    int n = NumberofSpecializations * 200;
                    TotalStudents = rand.Next(n, n *2);
                    Console.WriteLine("Information changed!");
                    OutputValues();
                    break;
                case '2':
                    Console.Write("Enter Number of Students: ");
                    while (!int.TryParse(Console.ReadLine(), out totalStudents) || TotalStudents < 200) //перевірка на правильність вводу
                    {
                        Console.Write("Wrong! Number of students has to be more 200.\nEnter Number of Students: ");
                    }
                    int m = TotalStudents / 200;
                    NumberofSpecializations = rand.Next(1, m);
                    NumberofDepartments = NumberofSpecializations;
                    Console.WriteLine("Information changed!");
                    OutputValues();
                    break;
                default:
                    Console.WriteLine("Nothing changed!");
                    break;
            }
        }
        else
            Console.WriteLine("Nothing changed!");

    }
}
    

