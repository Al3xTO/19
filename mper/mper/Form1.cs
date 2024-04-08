using System;
using System.Windows.Forms;

namespace mper
{
    public partial class Form1 : Form
    {
        private string currentName = "";
        private string currentWarriorType = "";
        private string currentHeightCategory = "";
        private string currentSpecialSkill = "";

        public Form1()
        {
            InitializeComponent();
            SetInitialCharacteristics();
        }

        private void SetInitialCharacteristics()
        {
            NameTemplate nameTemplate = new WesternNameTemplate();
            WarriorTemplate warriorTemplate = new WesternWarriorTemplate();

            currentName = nameTemplate.GenerateName();
            currentWarriorType = warriorTemplate.GenerateWarriorType();
            currentHeightCategory = warriorTemplate.GenerateWarriorHeightCategory();
            currentSpecialSkill = warriorTemplate.GenerateWarriorSpecialSkill();

            UpdateCharacteristicsLabels();
        }

        private void UpdateCharacteristicsLabels()
        {
            label1.Text = "Ім'я: " + currentName;
            label2.Text = "Тип воїна: " + currentWarriorType;
            label3.Text = "Зріст: " + currentHeightCategory;
            label4.Text = "Спеціальний навик: " + currentSpecialSkill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameTemplate nameTemplate = new WesternNameTemplate();
            currentName = nameTemplate.GenerateName();
            label1.Text = "Ім'я: " + currentName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WarriorTemplate warriorTemplate = new WesternWarriorTemplate();
            currentWarriorType = warriorTemplate.GenerateWarriorType();
            label2.Text = "Тип воїна: " + currentWarriorType;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WarriorTemplate warriorTemplate = new WesternWarriorTemplate();
            currentHeightCategory = warriorTemplate.GenerateWarriorHeightCategory();
            label3.Text = "Зріст: " + currentHeightCategory;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WarriorTemplate warriorTemplate = new WesternWarriorTemplate();
            currentSpecialSkill = warriorTemplate.GenerateWarriorSpecialSkill();
            label4.Text = "Спеціальний навик: " + currentSpecialSkill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Персонажа було створено з такими характеристиками:\n\nІм'я: {currentName}\nТип воїна: {currentWarriorType}\nЗріст: {currentHeightCategory}\nСпеціальний навик: {currentSpecialSkill}");
        }
    }

    abstract class NameTemplate
    {
        public string GenerateName()
        {
            string firstName = GenerateFirstName();
            return firstName;
        }

        protected abstract string GenerateFirstName();
    }

    class WesternNameTemplate : NameTemplate
    {
        protected override string GenerateFirstName()
        {
            string[] firstNames = { "Іван", "Михайло", "Христофор", "Давид", "Євген" };
            Random rnd = new Random();
            return firstNames[rnd.Next(firstNames.Length)];
        }
    }

    abstract class WarriorTemplate
    {
        public string GenerateWarriorType()
        {
            string type = GenerateType();
            return type;
        }

        public string GenerateWarriorHeightCategory()
        {
            string category = GenerateHeightCategory();
            return category;
        }

        public string GenerateWarriorSpecialSkill()
        {
            string specialSkill = GenerateSpecialSkill();
            return specialSkill;
        }

        protected abstract string GenerateType();
        protected abstract string GenerateHeightCategory();
        protected abstract string GenerateSpecialSkill();
    }

    class WesternWarriorTemplate : WarriorTemplate
    {
        protected override string GenerateType()
        {
            string[] types = { "Лицар", "Лучник", "Мечник", "Кінні рицар", "Рейнджер" };
            Random rnd = new Random();
            return types[rnd.Next(types.Length)];
        }

        protected override string GenerateHeightCategory()
        {
            string[] heightCategories = { "маленький", "середній", "великий" };
            Random rnd = new Random();
            return heightCategories[rnd.Next(heightCategories.Length)];
        }

        protected override string GenerateSpecialSkill()
        {
            string[] specialSkills = { "Блокування", "Прискорене відновлення здоров'я", "Сильний удар", "Лікування", "Точність" };
            Random rnd = new Random();
            return specialSkills[rnd.Next(specialSkills.Length)];
        }
    }
}
