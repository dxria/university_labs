namespace Lab3;
partial class Department
{
    private string nameDepartment;
    private int numberofProfessors;
    private int numberofStudents;
    private int numberofDisciplines;
    private int totalHoursofDisciplines;

    public Department()
    {
        nameDepartment = "";
        numberofProfessors = 0;
        numberofStudents = 0;
        numberofDisciplines = 0;
        totalHoursofDisciplines = 0;
    }
    public Department(string nameDepartment, int numberofProfessors, int numberofStudents, int numberofDisciplines, int totalHoursofDisciplines)
    {
        this.nameDepartment = nameDepartment;
        this.numberofProfessors = numberofProfessors;
        this.numberofStudents = numberofStudents;
        this.numberofDisciplines = numberofDisciplines;
        this.totalHoursofDisciplines = totalHoursofDisciplines; 
    }

    public string NameDepartment{ get { return nameDepartment; } set { nameDepartment = value; } }
    public int NumberofProfessors{ get { return numberofProfessors; } set { numberofProfessors = value; } }
    public int NumberofStudents { get { return numberofStudents; } set { numberofStudents = value; } }
    public int NumberofDisciplines { get { return numberofDisciplines; } set { numberofDisciplines = value; } }
    public int TotalHoursofDisciplines { get { return totalHoursofDisciplines; } set { totalHoursofDisciplines = value; } }
    public void EnterValues()
    {
        Console.Write("Department name: ");
        nameDepartment = Console.ReadLine();
        while (nameDepartment == null)
        {
            Console.Write("Department name: ");
            nameDepartment = Console.ReadLine();
        }
        Console.Write("Number of Professors: ");
        while (!int.TryParse(Console.ReadLine(), out numberofProfessors)) //перевірка на правильність вводу
        {
            Console.Write("Number of Professors: ");
        }
        Console.Write("Number of Students: ");
        while (!int.TryParse(Console.ReadLine(), out numberofStudents)) //перевірка на правильність вводу
        {
            Console.Write("Number of Students: ");
        }
        Console.Write("Number of Disciplines: ");
        while (!int.TryParse(Console.ReadLine(), out numberofDisciplines)) //перевірка на правильність вводу
        {
            Console.Write("Number of Disciplines: ");
        }
        Console.Write("Total amount of Hours of Discipline: ");
        while (!int.TryParse(Console.ReadLine(), out totalHoursofDisciplines)) //перевірка на правильність вводу
        {
            Console.Write("Total amount of Hours of Discipline: ");
        }
    }
    public void OutputValues()
    {
        Console.WriteLine("Department name: " + NameDepartment);
        Console.WriteLine("Number of Professors: " + NumberofProfessors);
        Console.WriteLine("Number of Students: " + NumberofStudents);
        Console.WriteLine("Number of Disciplines: " + NumberofDisciplines);
        Console.WriteLine("Total amount of Hours of Discipline: " + TotalHoursofDisciplines);
    }
    public void WriteToTXT()
    {
        StreamWriter writeFaculty = new StreamWriter(@"D:\my\c#\Lab3\Department_data.txt");
        writeFaculty.WriteLine("------------------------------------------\n" +
                               "Department name: " + NameDepartment + "\n" +
                               "Number of Professors: " + NumberofProfessors + "\n" +
                               "Number of Students: " + NumberofStudents + "\n" +
                               "Number of Disciplines: " + NumberofDisciplines + "\n" +
                               "Total amount of Hours of Disciplines: " + TotalHoursofDisciplines + "\n");
        writeFaculty.Close();
    }

    public class BranchChair
    {
        Random rand = new Random();
        public BranchChair()
        {
            CompanyName = "";
            CompanyRate = rand.Next(1,100);
            CompanyFinance = rand.Next(5000, 50000);
        }
        public string CompanyName { get; set; }
        public int CompanyRate { get; private set; }
        public int CompanyFinance { get; private set; }
        public void OutputValues()
        {
            Console.WriteLine("Company name: " + CompanyName);
            Console.WriteLine("Company rate number: " + CompanyRate);
            Console.WriteLine("Company finance input: " + CompanyFinance + "$");
        }
        public void QualityOfPreparation()
        {
            //Індекс KPI = ((Факт – База) / (Норма – База)) * 100%
            double fact = rand.Next(10, 100),
                basic = rand.Next(10, 40),
                norm = rand.Next(41, 80),
                indexKPI = 100.0 * ((fact - basic) / (norm - basic));
            Console.WriteLine($"The branch company base persantage is {basic}%, norm {norm}% and in fact they made {fact}% of all work.");
            Console.WriteLine($"KPI index for {CompanyName} is {indexKPI:0}% comparing to norm {norm}% and aim 100%");
        }
        public void OptimisationOfExpenses()
        {
            int SpecialistStudy = rand.Next(4000, 10000), lowSpecialistStudy = rand.Next(500,2000),
                VacancyAd = rand.Next(1000, 4000), lowVacancyAd = rand.Next(150, 500),
                EquipmentExpenses = rand.Next(5000, 15000), lowEquipmentExpenses = rand.Next(1500, 3000),
                CoursesExpances = rand.Next(2000, 6000), lowCoursesExpances = rand.Next(800, 1200);
            Console.WriteLine($"Restudying juniors now costs {SpecialistStudy}$ but the costs can be lowered to {SpecialistStudy-lowSpecialistStudy}$\n" +
                              $"Advertising of vacancies now costs {VacancyAd}$ but the costs can be lowered to {VacancyAd-lowVacancyAd}$\n" +
                              $"Expances on work equipment now costs {EquipmentExpenses}$ but the costs can be lowered to {EquipmentExpenses-lowEquipmentExpenses}$\n" +
                              $"Courses, trenings, seminars now costs {CoursesExpances}$ but the costs can be lowered to {CoursesExpances-lowCoursesExpances}$");

        }
    }

}
