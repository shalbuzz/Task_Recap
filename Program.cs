namespace Recap_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Weapon weapon1 = new Weapon(40, 30, FireMode.Single);
                Weapon weapon2 = new Weapon(50, 32, FireMode.Burst);
                Weapon weapon3 = new Weapon(40, 20, FireMode.Auto);

                Console.WriteLine("Please select from 0 to 7!");

                bool weaponMenu = true;
                while (weaponMenu)
                {
                    Console.WriteLine("0 - To get information");
                    Console.WriteLine("1 - For the Shoot method");
                    Console.WriteLine("2 - For the Fire method");
                    Console.WriteLine("3 - For the GetRemainBulletCount method");
                    Console.WriteLine("4 - For the Reload method");
                    Console.WriteLine("5 - For the ChangeFireMode method");
                    Console.WriteLine("6 - To quit the program");
                    Console.WriteLine("7 - Edit");
                    

                    string choose = Console.ReadLine();
                    Console.Clear();
                    switch (choose)
                    {
                        case "0":
                            Console.Clear();
                            Console.WriteLine(weapon1.ToString());
                            break;
                        case "1":
                            try
                            {
                                weapon1.Shoot();
                                Console.Clear();
                                Console.WriteLine("Shot fired.");
                            }
                            catch (NotAvailableException ex)
                            {
                                Console.Clear();
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case "2":
                            try
                            {
                                weapon1.Fire();
                                Console.Clear();
                                Console.WriteLine("Firing mode executed.");
                            }
                            catch (NotAvailableException ex)
                            {
                                Console.Clear();
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine($"Remaining bullets: {weapon1.GetRemainBulletCount()}");
                            break;

                        case "4":
                            weapon1.Reload();
                            Console.Clear();
                            Console.WriteLine("Weapon reloaded.");
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Enter fire mode: Single, Burst, or Auto");
                            string mode = Console.ReadLine();
                           
                            FireMode newMode;
                            switch (mode.ToLower())
                            {
                                case "single":
                                    newMode = FireMode.Single;
                                    weapon1.ChangeFireMode(newMode);
                                    Console.Clear();
                                    Console.WriteLine($"Fire mode changed to: {newMode}");
                                    break;
                                case "burst":
                                    newMode = FireMode.Burst;
                                    weapon1.ChangeFireMode(newMode);
                                    Console.Clear();
                                    Console.WriteLine($"Fire mode changed to: {newMode}");
                                    break;
                                case "auto":
                                    newMode = FireMode.Auto;
                                    weapon1.ChangeFireMode(newMode);
                                    Console.Clear();
                                    Console.WriteLine($"Fire mode changed to: {newMode}");
                                    break;
                                default:
                                    Console.Clear();
                                    try
                                    {
                                        if (string.IsNullOrEmpty(mode) || string.IsNullOrWhiteSpace(mode))
                                        {
                                            throw new NotAvailableException("Firemode cannot be a null or '' ");
                                        }

                                        else
                                        {
                                            throw new NotAvailableException("Fremode cannot be any string except: single, burst, auto ");
                                        }
                                    }
                                    catch (NotAvailableException ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;

                            }
                            break;

                        case "6":
                            weaponMenu = false;
                            Console.Clear();
                            Console.WriteLine("Exiting weapon menu.");
                            break;


                        case "7":
                            Console.Clear();
                            Console.WriteLine("8 - Сhange Capacity");
                            Console.WriteLine("9 - Change Count");
                   
                            string edit = Console.ReadLine();
                            try
                            {
                                if (string.IsNullOrEmpty(edit) || string.IsNullOrWhiteSpace(edit))
                                {
                                    throw new NotAvailableException("Capacity cannot be a string or '' ");
                                }

                                int newEdit = int.Parse(edit);


                            }
                            catch (FormatException)
                            {
                                Console.Clear();
                                Console.WriteLine("Error: BulletCount must be a valid number.");
                            } 
                            catch(NotAvailableException ex)
                            {
                                Console.Clear();
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                                switch (edit)
                                {
                                    case "8":
                                    Console.Clear();
                                    Console.WriteLine("Enter a new Capacity");
                                        string input = Console.ReadLine();
                                        try
                                        {
                                            if (string.IsNullOrWhiteSpace(input))
                                            {
                                                throw new NotAvailableException("Capacity cannot be a string or '' ");

                                            }
                                            int newCapacity = int.Parse(input);
                                            if (newCapacity <= 0)
                                            {

                                                throw new NotAvailableException("Capacity cannot less than 0");
                                            }


                                            weapon1.BulletCapacity = newCapacity;
                                        Console.Clear();
                                        Console.WriteLine($"Capacity successfully updated: {weapon1.BulletCapacity}");

                                        }
                                        catch (FormatException)
                                        {
                                        Console.Clear();
                                        Console.WriteLine("Error: BulletCount must be a valid number.");
                                        }
                                        catch (NotAvailableException ex)
                                        {
                                        Console.Clear();
                                        Console.WriteLine($"Error: {ex.Message}");
                                        }

                                        break;

                                    case "9":
                                    Console.Clear();
                                    Console.WriteLine("Enter the new BulletCount");
                                        string input2 = Console.ReadLine();
                                        try
                                        {

                                            if (string.IsNullOrWhiteSpace(input2))
                                            {
                                                throw new NotAvailableException("Capacity cannot be a string or '' ");
                                            }
                                            int newBulletCount = int.Parse(input2);



                                            if (newBulletCount <= 0)
                                            {
                                                throw new NotAvailableException("BulletCount cannot be negative");
                                            }
                                            if (newBulletCount > weapon1.BulletCapacity)
                                            {
                                                throw new NotAvailableException($"Cannot exceed the capacity of the weapon ({weapon1.BulletCapacity}).");
                                            }
                                            weapon1.BulletCount = newBulletCount;
                                        Console.Clear();
                                        Console.WriteLine($"BulletCount successfully updated: {weapon1.BulletCount}");
                                        }
                                        catch (FormatException)
                                        {
                                        Console.Clear();
                                        Console.WriteLine("Error: BulletCount must be a valid number.");
                                        }
                                        catch (NotAvailableException ex)
                                        {
                                        Console.Clear();
                                        Console.WriteLine($"Error: {ex.Message}");
                                        }
                                        break;


                                }
                            
                        break;


                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid choice, please try again.");
                            break;



                    }
                }



            }
            catch (Exception ex) { Console.WriteLine($"General error:{ex.Message}"); }
        }

   }
            



 }
    

