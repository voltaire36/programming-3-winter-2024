using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;



namespace ManageStockData
{
    public partial class Form1 : Form
    {
        string dataSourceFile = null;

        List<Stock> stockList = null;
        public Form1()
        {

            InitializeComponent();


            // Added by me> Voltaire Rono 
            btnSortOnSymbol.Click += new EventHandler(btnSortOnSymbol_Click);
            btnSortDate.Click += new EventHandler(btnSortDate_Click);
            btnSortOnOpen.Click += new EventHandler(btnSortOnOpen_Click);

        }


        public void LoadData(string filePath)
        {

            char[] charsToTrim = { '$', ' ', '(', ')' };
            StreamReader sr = new StreamReader(filePath);
            {
                Stock item;
                var headers = sr.ReadLine()?.Split(',');
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');
                    if (headers != null && values.Length == headers.Length)
                    {
                        item = new Stock(values[0].Trim(), DateOnly.Parse(values[1].Trim()),
                                                System.Convert.ToDecimal(values[2].Trim(charsToTrim)),
                                                System.Convert.ToDecimal(values[3].Trim(charsToTrim)),
                                                System.Convert.ToDecimal(values[4].Trim(charsToTrim)),
                                                System.Convert.ToDecimal(values[5].Trim(charsToTrim)));
                        stockList.Add(item);
                    }
                }
            }
        }






        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),

                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataSourceFile = openFileDialog1.FileName;
            }

            LoadData(dataSourceFile);

            ShowResult();
        }

        private void ShowResult()
        {
            Helper.result.Clear();

            Helper.result.AppendLine(System.String.Format("{0,-30}  {1,-30}  {2,-20}  {3,-20} {4,-20} {5,-20} ", "Stock Symbol", "Date", "Open Price", "High Price", "Low Price", "Close Price"));

            foreach (var item in stockList)
            {
                Helper.result.AppendLine("\n" + item.ToString() + "\n");
            }

            textBoxResult.Text = Helper.result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stockList = new List<Stock>();
        }

        // Added by me> Voltaire Rono 
        private void btnSortOnSymbol_Click(object sender, EventArgs e)
        {
            BubbleSort.Sort(stockList, (x, y) => x.Symbol.CompareTo(y.Symbol) < 0);
            ShowResult();
        }

        // Added by me> Voltaire Rono 
        private void btnSortDate_Click(object sender, EventArgs e)
        {
            BubbleSort.Sort(stockList, (x, y) => x.Date.CompareTo(y.Date) < 0);
            ShowResult();
        }

        // Added by me> Voltaire Rono 
        private void btnSortOnOpen_Click(object sender, EventArgs e)
        {
            BubbleSort.Sort(stockList, (x, y) => x.Open.CompareTo(y.Open) < 0);
            ShowResult();
        }
    }
}
