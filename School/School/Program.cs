namespace School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            School schoolOne = new School("scuola", 2);
            Class onceA = new Class('A', 1);
            Class secondA = new Class('A', 2);
            Class thirdA = new Class('A', 3);
            Class fourthA = new Class('A', 4);
            Class fifthA = new Class('A', 5);
            Class onceB = new Class('B', 1);
            Class secondB = new Class('B', 2);
            Class thirdB = new Class('B', 3);
            Class fourthB = new Class('B', 4);
            Class fifthB = new Class('B', 5);
            Class onceC = new Class('C', 1);
            Class secondC = new Class('C', 2);
            Class thirdC = new Class('C', 3);
            
            schoolOne.AssignsClassToPlexus(onceA);
            schoolOne.AssignsClassToPlexus(secondA);
            schoolOne.AssignsClassToPlexus(thirdA);
            schoolOne.AssignsClassToPlexus(fourthA);
            schoolOne.AssignsClassToPlexus(fifthA);
            schoolOne.AssignsClassToPlexus(onceB);
            schoolOne.AssignsClassToPlexus(secondB);
            schoolOne.AssignsClassToPlexus(thirdB);
            schoolOne.AssignsClassToPlexus(fourthB);
            schoolOne.AssignsClassToPlexus(fifthB);
            schoolOne.AssignsClassToPlexus(onceC);
            schoolOne.AssignsClassToPlexus(secondC);
            schoolOne.AssignsClassToPlexus(thirdC);
        }
    }
}