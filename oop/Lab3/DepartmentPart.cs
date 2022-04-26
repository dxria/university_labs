namespace Lab3;
partial class Department
{
    public void CountWorkload()
    {
        if (NumberofDisciplines == 0 || NumberofProfessors==0)
        {
            Console.WriteLine("Firstly enter values to your Department!");
        }
        else
        {
            int ratio = NumberofStudents / NumberofProfessors;
            int load = TotalHoursofDisciplines / NumberofProfessors;
            int duration = TotalHoursofDisciplines / NumberofDisciplines;

            bool isCorrect = (ratio <= 10 && load <= 600 && duration >= 90) ? true : false;
            if (isCorrect)
            {
                Console.WriteLine("Current Workload is optimised!");
            }
            else
            {
                ratio = NumberofStudents / 10; // Suggestion of number of professors
                duration = NumberofDisciplines*90; // Suggestion of total amouny of disciplines
                load = duration / 600; // Suggestion of number of professors
                Console.WriteLine("Currect Workload isn't suitable. To improve your workload follow these countings:\n" +
                                  $"Optimal total amount of time for disciplines is {duration}\n" +
                                  $"Optimal number of professors: {Math.Max(ratio, load)}");
            }
        }
        
    }
}
