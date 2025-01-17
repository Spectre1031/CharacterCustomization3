﻿using CharacterCustomization;
using System;

namespace CharacterCreationSystem
{
    public interface IShowOptions
    {
        void ShowNameOptions();
        void ShowAgeOptions();
        void ShowGenderOptions();
        void ShowRaceOptions();
        void ShowFarmerTypeOptions();
    }

    public class CharacterInfo
    {
        private string name;
        private string age;
        private string gender;
        private string race;
        private string farmerType;

        public CharacterInfo(string name, string age, string gender, string race, string farmerType)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.race = race;
            this.farmerType = farmerType;
        }
        public void SetName(string name) { this.name = name; }
        public void SetAge(string age) { this.age = age; }
        public void SetGender(string gender) { this.gender = gender; }
        public void SetRace(string race) { this.race = race; }
        public void SetFarmerType(string farmerType) { this.farmerType = farmerType; }

        public string GetName() { return name; }
        public string GetAge() { return age; }
        public string GetGender() { return gender; }
        public string GetRace() { return race; }
        public string GetFarmerType() { return farmerType; }

        
    }

    public class CustomCharacterInfo : CheckForErrors, IShowOptions
    {
        private CharacterInfo characterInfo;

        public CustomCharacterInfo() { characterInfo = new CharacterInfo("", "", "", "", ""); }

        public void CustomizeInfo()
        {
            Console.WriteLine("\n=== Customize Character Info ===");
            SetName();
            SetAge();
            SetGender();
            SetRace();
            SetFarmerType();
        }

        private void SetName()
        {
            while (string.IsNullOrEmpty(characterInfo.GetName()))
            {
                Console.WriteLine("\n=== Character Name ===");
                ShowNameOptions();
                Console.Write("Enter Name: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && input.Length >= 3 && input.Length <= 16)
                {
                    characterInfo.SetName(input);
                }
                else
                {
                    Console.WriteLine("Name must be 3-16 characters long.");
                }
            }
        }

        private void SetAge()
        {
            while (string.IsNullOrEmpty(characterInfo.GetAge()))
            {
                Console.WriteLine("\n=== Character Age ===");
                ShowAgeOptions();
                Console.Write("Enter choice: ");
                characterInfo.SetAge(CheckForErrors.CheckInput(Console.ReadLine(), new[]
                {
                    "Young Adult (18-24)", "Adult (25-31)", "Middle-Aged (32-38)",
                    "Mature Adult (39-45)", "Experienced (46-52)"
                }));
            }
        }

        private void SetGender()
        {
            while (string.IsNullOrEmpty(characterInfo.GetGender()))
            {
                Console.WriteLine("\n=== Character Gender ===");
                ShowGenderOptions();
                Console.Write("Enter choice: ");
                characterInfo.SetGender(CheckForErrors.CheckInput(Console.ReadLine(), new[] { "Male", "Female", "Non-Binary", "Other" }));
            }
        }

        private void SetRace()
        {
            while (string.IsNullOrEmpty(characterInfo.GetRace()))
            {
                Console.WriteLine("\n=== Character Race ===");
                ShowRaceOptions();
                Console.Write("Enter choice: ");
                characterInfo.SetRace(CheckForErrors.CheckInput(Console.ReadLine(), new[]
                {
                    "Western European", "Asian", "Native American", "Australian", "Middle Eastern"
                }));
            }
        }

        private void SetFarmerType()
        {
            while (string.IsNullOrEmpty(characterInfo.GetFarmerType()))
            {
                Console.WriteLine("\n=== Character Farmer Type ===");
                ShowFarmerTypeOptions();
                Console.Write("Enter choice: ");
                characterInfo.SetFarmerType(CheckForErrors.CheckInput(Console.ReadLine(), new[]
                {
                    "Crop Farmer", "Livestock Farmer", "Mixed Farmer", "Organic Farmer", "Aquaculture Farmer"
                }));
            }
        }

        public void ShowDetailInfo()
        {
            Console.WriteLine($"{"Name:",-15} {characterInfo.GetName()}");
            Console.WriteLine($"{"Age:",-15} {characterInfo.GetAge()}");
            Console.WriteLine($"{"Gender:",-15} {characterInfo.GetGender()}");
            Console.WriteLine($"{"Race:",-15} {characterInfo.GetRace()}");
            Console.WriteLine($"{"Farmer Type:",-15} {characterInfo.GetFarmerType()}");
        }

        public void ShowNameOptions() { Console.WriteLine("Name must be 3-16 characters long."); }
        public void ShowAgeOptions()
        {
            Console.WriteLine("(a) Young Adult (18-24)");
            Console.WriteLine("(b) Adult (25-31)");
            Console.WriteLine("(c) Middle-Aged (32-38)");
            Console.WriteLine("(d) Mature Adult (39-45)");
            Console.WriteLine("(e) Experienced (46-52)");
        }
        public void ShowGenderOptions()
        {
            Console.WriteLine("(a) Male");
            Console.WriteLine("(b) Female");
            Console.WriteLine("(c) Non-Binary");
            Console.WriteLine("(d) Other");
        }
        public void ShowRaceOptions()
        {
            Console.WriteLine("(a) Western European");
            Console.WriteLine("(b) Asian");
            Console.WriteLine("(c) Native American");
            Console.WriteLine("(d) Australian");
            Console.WriteLine("(e) Middle Eastern");
        }
        public void ShowFarmerTypeOptions()
        {
            Console.WriteLine("(a) Crop Farmer");
            Console.WriteLine("(b) Livestock Farmer");
            Console.WriteLine("(c) Mixed Farmer");
            Console.WriteLine("(d) Organic Farmer");
            Console.WriteLine("(e) Aquaculture Farmer");
        }
    }

    public class CheckForErrors
    {
        public static string CheckInput(string input, string[] options)
        {
            if (input.Length == 1)
            {
                return chosenOps(Char.Parse(input.ToLower()), choose);
            }
            else { throw new OnlyOneCharacter("Must be one character only"); }
        }
        public static string chosenOps(char letter, string[] choose)
        {
            string[] shapess = choose;

            switch (letter)
            {
                case 'a': return shapess[0];
                case 'b': return shapess[1];
                case 'c': return shapess[2];
                case 'd': return shapess[3];
                case 'e': return shapess[4];
                case 'f': return shapess[5];
                case 'g': return shapess[6];
                default: throw new IndexOutOfRangeException();
            }
        }
    }
    public class OnlyOneCharacter : Exception
    {
        public OnlyOneCharacter(string message) : base(message) { }
    }
}
