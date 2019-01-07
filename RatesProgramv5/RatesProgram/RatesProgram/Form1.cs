using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RatesProgram
{
    public partial class Application : Form
    {
        public class XmlParser
        {
            public List<string> validCurrencyPairs = new List<string>();
            public string[] pairAttributes = new string[6];
            public XmlParser() { }

            public void SetCurrencyPairList()
            {
                XmlReader reader = XmlReader.Create("https://rates.fxcm.com/RatesXML");
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Rate"))
                    {
                        if (reader.HasAttributes)
                        {
                            validCurrencyPairs.Add(reader.GetAttribute("Symbol"));
                        }
                    }
                }
            }

            public List<string> GetCurrencyPairList()
            {
                return validCurrencyPairs;
            }

            public void SetPairAttributes(string currencyPair)
            {
                XmlReader reader = XmlReader.Create("https://rates.fxcm.com/RatesXML");

                while (reader.Read())
                {
                    if (!reader.ReadToFollowing("Rate")) //Jumps to the Rate Element in XML Page, once it returns false, we have reached the end and break
                        break;

                    //pairAttributes is set only with the Symbol user has input as currencyPair
                    if (reader.HasAttributes && reader.GetAttribute("Symbol") == currencyPair)
                    {
                        reader.ReadToFollowing("Bid");
                        pairAttributes[0] = reader.ReadElementContentAsString();
                        reader.ReadToFollowing("Ask");
                        pairAttributes[1] = reader.ReadElementContentAsString();
                        reader.ReadToFollowing("High");
                        pairAttributes[2] = reader.ReadElementContentAsString();
                        reader.ReadToFollowing("Low");
                        pairAttributes[3] = reader.ReadElementContentAsString();
                        reader.ReadToFollowing("Direction");
                        pairAttributes[4] = reader.ReadElementContentAsString();
                        reader.ReadToFollowing("Last");
                        pairAttributes[5] = reader.ReadElementContentAsString();
                    }
                }
            }

            public string[] GetPairAttributes()
            {
                return pairAttributes;
            }
        }

        //Method will test both the Currency Symbol and the Rate the user has input into the program.
        //Symbol must be found in List of valid symbols. Rate must not return error when converting to 
        //float value, and must fall within appropriate range for a Currency Rate. If conditions aren't
        //met, User is asked to input data once again.
        public static bool DataValidation(XmlParser aParser, string currencyPair, string targetRate)
        {
            bool currency = false, rate = false;
            float realRate = -1;
            for (int i = 0; i < aParser.GetCurrencyPairList().Count; i++)
            {
                if (aParser.GetCurrencyPairList()[i] == currencyPair)
                    currency = true;
            }

            if (!currency)
            {
                Console.WriteLine("Symbol not found, Enter Valid Symbol and Rate");
                return false;
            }

            try
            {
                realRate = float.Parse(targetRate);
            }
            catch
            {
                Console.WriteLine("Format for number not accepted");
            }

            if (realRate > 0 && realRate < 100000)
                rate = true;

            if (!rate)
            {
                Console.WriteLine("Input not accepted, please enter valid Symbol and Rate");
                return false;
            }

            return true;
        }

        // Create Timer object
        private Timer timer1;
        // Function to start timer
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();
        }
        
        // Execute code every x amount of time
        private void timer1_Tick(object sender, EventArgs e)
        {
            xmlParserObject.SetPairAttributes(targetCurrencyPair);

            float bid, ask, high, low, direction;
            string last;
            bid = float.Parse(xmlParserObject.GetPairAttributes()[0]);
            ask = float.Parse(xmlParserObject.GetPairAttributes()[1]);
            high = float.Parse(xmlParserObject.GetPairAttributes()[2]);
            low = float.Parse(xmlParserObject.GetPairAttributes()[3]);
            direction = float.Parse(xmlParserObject.GetPairAttributes()[4]);
            last = xmlParserObject.GetPairAttributes()[5];
            pairAttributesTextBox.Text = string.Format("Symbol = {0}\r\n <Bid> {1}\r\n <Ask> {2}\r\n <High> {3}\r\n <Low> {4}\r\n <Direction> {5}\r\n <Last> {6}\r\n", targetCurrencyPair, bid, ask, high, low, direction, last);

            targetRate = float.Parse(testRate);
            //Compares target rate and bid should be here

             if (targetRate < startBid)
                {
                if (bid <= targetRate)
                {
                    timer1.Stop();
                    startButton.Text = "Start";
                    desiredTargetRateTextBox.ReadOnly = false;
                    currencyPairListBox.Enabled = true;
                    MessageBox.Show("Currency pair rate has reached the target rate! <Bid> of " + targetCurrencyPair + " is " + bid + ".");
                }
            }
             else if (targetRate > startBid)
            {
                if (bid >= targetRate)
                {
                    timer1.Stop();
                    startButton.Text = "Start";
                    desiredTargetRateTextBox.ReadOnly = false;
                    currencyPairListBox.Enabled = true;
                    MessageBox.Show("Currency pair rate has reached the target rate! <Bid> of " + targetCurrencyPair + " is " + bid + ".");
                }
            }
             else
            {
                timer1.Stop();
                startButton.Text = "Start";
                desiredTargetRateTextBox.ReadOnly = false;
                currencyPairListBox.Enabled = true;
                MessageBox.Show("Currency pair rate has reached the target rate! <Bid> of " + targetCurrencyPair + " is " + bid + ".");
            }
        }

        // Keep track of user's desired currency pair
        string targetCurrencyPair = "";
        // Keep track of user's desired target rate
        float targetRate = 0;
        string testRate = "";

        // Create XmlParser object
        XmlParser xmlParserObject = new XmlParser();

        public Application()
        {
            InitializeComponent();

            // Create list of valid currency pairs
            xmlParserObject.SetCurrencyPairList();

            // Adds list items into itembox for UI
            for (int i = 0; i < xmlParserObject.GetCurrencyPairList().Count; i++)
            {
                currencyPairListBox.Items.Add(xmlParserObject.GetCurrencyPairList()[i]);
            }
        }

        // Event Handler to display selected currency pair in selectedCurrencyPairTextBox
        private void SelectedIndexChange(object sender, EventArgs e)
        {
            ListBox selectedCurrencyPair = sender as ListBox;
            if (selectedCurrencyPair != null)
            {
                selectedCurrencyPairTextBox.Text = selectedCurrencyPair.SelectedItem.ToString();
                targetCurrencyPair = selectedCurrencyPair.SelectedItem.ToString();
            }
        }

        private void TextChanged(object sender, EventArgs e)
        {
            TextBox desiredTargetRate = sender as TextBox;
            if (desiredTargetRate != null)
            {
                testRate = desiredTargetRate.Text;
            }
        }

        float startBid = 0; // for if else in timer1 logic

        private void startButton_Click(object sender, EventArgs e)
        {
            //Check
            if (startButton.Text == "Stop")
            {
                timer1.Stop();
                startButton.Text = "Start";
                desiredTargetRateTextBox.ReadOnly = false;
                currencyPairListBox.Enabled = true;
            }
            else if (DataValidation(xmlParserObject, targetCurrencyPair, testRate))
            {
                // if correct do this
                InitTimer();
                startButton.Text = "Stop";
                desiredTargetRateTextBox.ReadOnly = true;
                currencyPairListBox.Enabled = false;
                xmlParserObject.SetPairAttributes(targetCurrencyPair); // for if else timer1 logic
                startBid = float.Parse(xmlParserObject.GetPairAttributes()[0]); // for if else timer1 logic
            } 
            else
            {
                // if incorrect display message
                MessageBox.Show("Invalid Input! Try Again.");
            }
        }

        private void Application_Load(object sender, EventArgs e)
        {

        }
    }
}