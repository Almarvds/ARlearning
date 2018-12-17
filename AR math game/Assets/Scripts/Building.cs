using System;

internal class Building
{
    public String Name;
    public String description;
    public int Wood;
    public int Paint;
    public int Designs;
    public int Bricks;


    public Building()
    {
       
    }

    public void isBuilding(String _Name)
    {

        Name = _Name;

        if(Name == "Hospital")
        {
            description = "The number one place to go when you are not feeling well.";
            Wood = 3;
            Paint = 2;
            Designs = 3;
            Bricks = 5;
        }

        if (Name == "House")
        {
            description = "Everyone in the world needs a home.";
            Wood = 3;
            Paint = 3;
            Designs = 2;
            Bricks = 3;
        }

        if (Name == "House2")
        {
            description = "A happy place for a happy inhabitant.";
            Wood = 4;
            Paint = 3;
            Designs = 4;
            Bricks = 4;
        }

        if (Name == "Police station")
        {
            description = "You will need some heroes to fight crime.";
            Wood = 5;
            Paint = 5;
            Designs = 5;
            Bricks = 6;
        }

        if (Name == "School")
        {
            description = "A place for leaning and such.";
            Wood = 5;
            Paint = 6;
            Designs = 5;
            Bricks = 4;
        }
    }
}
