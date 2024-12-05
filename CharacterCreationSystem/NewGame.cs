using System;
using CharacterCustomization;
using CharacterCreationSystem;
using static CharacterCreationSystem.CharacterInfo;

namespace CharacterCreationSystem
{
    public class NewGame
    {
        public void CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("=== NEW GAME: Create Your Character ===");

            CustomCharacterInfo customcharacterInfo = new CustomCharacterInfo();
            CharacterAttributes.CustomAttributes customAttributes = new CharacterAttributes.CustomAttributes();

            CustomAppearance customAppearance = new CustomAppearance();

            customcharacterInfo.CustomizeInfo();
            customAttributes.CustomizeAttributes();
            customAppearance.CustomizeAppearance();

            string name = characterInfo.GetName();
            string age = characterInfo.GetAge();
            string gender = characterInfo.GetGender();
            string race = characterInfo.GetRace();
            string farmerType = characterInfo.GetFarmerType();
            string positiveEffect = customAttributes.GetPositiveEffect();
            string negativeEffect = customAttributes.GetNegativeEffect();
            string tools = customAttributes.GetTools();
            string accessories = customAppearance.GetAccessory();
            string clothes = customAppearance.GetClothes();

            int strength = customAttributes.GetStrength();
            int luck = customAttributes.GetLuck();
            int speed = customAttributes.GetSpeed();
            int endurance = customAttributes.GetEndurance();
            int dexterity = customAttributes.GetDexterity();
            int intelligence = customAttributes.GetIntelligence();

            Console.WriteLine("\n=== Character Summary ===");
            customcharacterInfo.ShowDetailInfo();
            Console.WriteLine($"{"Strength:",-20} {strength}");
            Console.WriteLine($"{"Luck:",-20} {luck}");
            Console.WriteLine($"{"Speed:",-20} {speed}");
            Console.WriteLine($"{"Endurance:",-20} {endurance}");
            Console.WriteLine($"{"Dexterity:",-20} {dexterity}");
            Console.WriteLine($"{"Intelligence:",-20} {intelligence}");
            Console.WriteLine($"{"Positive Effect:",-20} {positiveEffect}");
            Console.WriteLine($"{"Negative Effect:",-20} {negativeEffect}");
            Console.WriteLine($"{"Tools:",-20} {tools}");

            Console.WriteLine("\n=== Appearance Details ===");
            customAppearance.showDetailAppearance();
            Console.WriteLine($"{"Accessories:",-20} {accessories}");
            Console.WriteLine($"{"Clothes:",-20} {clothes}");

            Console.WriteLine("\nCharacter creation complete! Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
