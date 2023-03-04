const int UNKNOWN = -1;
const int INTRO_SCENE = 0;
const int SHOW_SHADOW_FIGURE = 1;
const int SHOW_SKELETONS = 2;
const int HAUNTED_ROOM = 3;
const int CAMERA_SCENE = 4;
const int STRANGE_CREATURE = 5;
const int EXIT = 6;
const string PLAYER_FOUND_EXIT = "You made it! You've found an exit.";
const string NO_ROOM = "There is no room!";
const string ENTER_VALID_DIRECTION = "Please enter a valid direction!";
int room = INTRO_SCENE;


bool IsGoulAlive = true;
bool PlayerFoundWeapon = false;
bool goOn = false;

System.Console.WriteLine("Welcome to the Adventure Game!");
System.Console.WriteLine("==============================");
System.Console.WriteLine("As an avid traveler, you have decided to visit the Catacombs of Paris.");
System.Console.WriteLine("However, during your exploration, you find yourself lost.");
System.Console.WriteLine("You can choose to walk in multiple directions to find a way out.");
System.Console.Write("Let's start with your name: ");
string name = Console.ReadLine()!;

System.Console.WriteLine($"Good luck, {name}!");


while (!goOn)
{
    switch (room)
    {
        case INTRO_SCENE:
            IntroScene();
            break;
        case SHOW_SHADOW_FIGURE:
            ShowShadowFigure();
            break;
        case CAMERA_SCENE:
            CameraScene();
            break;
        case HAUNTED_ROOM:
            HauntedRoom();
            break;
        case SHOW_SKELETONS:
            ShowSkeletons();
            break;
        case STRANGE_CREATURE:
            StrangeCreature();
            break;
        case EXIT:
            goOn = true;
            break;
        default:
            Console.WriteLine(NO_ROOM);
            goOn = true;
            break;
    }
}



void IntroScene()
{
    Console.WriteLine("You are at a crossroads, and you can choose to go down any of the four hallways. Where would you like to go?");
    string direction = "";
    room = UNKNOWN;
    while (room == UNKNOWN)
    {
        direction = Console.ReadLine()!;
        switch (direction)
        {
            case "west":
                room = SHOW_SHADOW_FIGURE;
                break;
            case "east":
                room = SHOW_SKELETONS;
                break;
            case "south":
                room = HAUNTED_ROOM;
                break;
            case "north":
                DeadEnd();
                break;
            default:
                Console.WriteLine(ENTER_VALID_DIRECTION);
                break;
        }
    }
}

void ShowShadowFigure()
{
    System.Console.WriteLine("You see a dark shadowy figure appear in the distance.");
    System.Console.WriteLine("Where would you like to go?");
    string direction = "";
    room = UNKNOWN;
    while (room == UNKNOWN)
    {
        direction = Console.ReadLine()!;
        switch (direction)
        {
            case "east":
                room = INTRO_SCENE;
                break;
            case "south":
                DeadEnd();
                break;
            case "north":
                room = CAMERA_SCENE;
                break;
            default:
                Console.WriteLine(ENTER_VALID_DIRECTION);
                break;
        }
    }
}

void CameraScene()
{
    System.Console.WriteLine("You see a camera that has been dropped on the ground.");
    System.Console.WriteLine("Where would you like to go?");
    string direction = "";
    room = UNKNOWN;
    while (room == UNKNOWN)
    {
        direction = Console.ReadLine()!;
        switch (direction)
        {
            case "south":
                room = SHOW_SHADOW_FIGURE;
                break;
            case "north":
                room = EXIT;
                break;
            default:
                Console.WriteLine(ENTER_VALID_DIRECTION);
                break;
        }
    }
}

void HauntedRoom()
{
    System.Console.WriteLine("You hear strange voices. You think you have awoken some of the dead.");
    System.Console.WriteLine("Where would you like to go?");
    string direction = "";
    room = UNKNOWN;
    while (room == UNKNOWN)
    {
        direction = Console.ReadLine()!;
        switch (direction)
        {
            case "west":
                Console.WriteLine("Multiple goul-like creatures start emerging as you enter the room. You are killed.");
                room = EXIT;
                break;
            case "east":
                Console.WriteLine(PLAYER_FOUND_EXIT);
                room = EXIT;
                break;
            case "north":
                room = INTRO_SCENE;
                break;
            default:
                Console.WriteLine(ENTER_VALID_DIRECTION);
                break;
        }
    }
}

void ShowSkeletons()
{
    System.Console.WriteLine("You see a wall of skeletons as you walk into the room. Someone is watching you");
    System.Console.WriteLine("Where would you like to go?");
    string direction = "";
    room = UNKNOWN;
    while (room == UNKNOWN)
    {
        direction = Console.ReadLine()!;
        switch (direction)
        {
            case "north":
                Console.Write("You find that this door opens into a wall.");
                if (!PlayerFoundWeapon)
                {
                    Console.WriteLine(" You open some of the drywall to discover a knife.");
                }
                else
                {
                    Console.WriteLine();
                }
                PlayerFoundWeapon = true;
                direction = "";
                break;
            case "west":
                room = INTRO_SCENE;
                break;
            case "east":
                room = STRANGE_CREATURE;
                break;
            default:
                Console.WriteLine(ENTER_VALID_DIRECTION);
                break;
        }
    }
}

void StrangeCreature()
{
    if (IsGoulAlive)
    {
        Console.WriteLine("A strange goul-like creature has appeared. You can either run or fight it. What would you like to do?");
    }
    string direction = "";
    room = UNKNOWN;
    while (room == UNKNOWN)
    {
        if (IsGoulAlive)
        {
            Console.WriteLine("Do you want to flee or fight");
        }
        direction = Console.ReadLine()!;
        switch (direction)
        {
            case "fight":
                if (PlayerFoundWeapon)
                {
                    Console.WriteLine("You kill the goul with the knife you found earlier.");
                    IsGoulAlive = false;
                    System.Console.WriteLine("Where do you want to go?");
                    direction = Console.ReadLine()!;
                    switch (direction)
                    {
                        case "south":
                            room = EXIT;
                            break;
                        default:
                            Console.WriteLine(ENTER_VALID_DIRECTION);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("The goul-like creature has killed you.");
                    room = EXIT;
                }
                break;
            case "flee":
                room = SHOW_SKELETONS;
                break;
            default:
                Console.WriteLine(ENTER_VALID_DIRECTION);
                break;
        }
    }
}


string DeadEnd()
{
    return "You find that this door opens into a wall.";
}
