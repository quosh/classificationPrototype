using System;
using System.Windows.Forms;


namespace ClassificationData
{
	public partial class frmMain : Form
	{
	

		public frmMain()
		{
			InitializeComponent();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnList_Click(object sender, EventArgs e)
		{
			string _xmlInput = " ";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				System.IO.StreamReader sr = new
				   System.IO.StreamReader(openFileDialog1.FileName);

				_xmlInput = sr.ReadToEnd();
				sr.Close();
			}

			ClassificationDataProducer classData = new ClassificationDataProducer();
			classData.inputXml = _xmlInput;
			classData.processDrugs();
			rtbOutput.Clear();

			//output totals
			rtbOutput.AppendText("No of classes processed: " + classData.classCount.ToString() + System.Environment.NewLine);
			rtbOutput.AppendText("No of drugs processed: " + classData.drugCount.ToString() + System.Environment.NewLine);

			//output json
			rtbOutput.AppendText(classData.outputJson);

		}

		//Latest
		private void button1_Click(object sender, EventArgs e)
		{
			string _xmlInput = " ";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				System.IO.StreamReader sr = new
				   System.IO.StreamReader(openFileDialog1.FileName);

				_xmlInput = sr.ReadToEnd();
				sr.Close();
			}

			ClassDataProducerV2 classData = new ClassDataProducerV2();
			classData.inputXml = _xmlInput;
			classData.processDrugs();
			rtbOutput.Clear();

			//output totals
			rtbOutput.AppendText("No of classes processed: " + classData.classCount.ToString() + System.Environment.NewLine);
			rtbOutput.AppendText("No of drugs processed: " + classData.drugCount.ToString() + System.Environment.NewLine);
			rtbOutput.AppendText("No of drugs added to a list: " + classData.drugsAdded.ToString() + System.Environment.NewLine);


			//output json
			rtbOutput.AppendText(classData.outputJson);

		}

		private void button2_Click(object sender, EventArgs e)
		{
			string _xmlInput = "";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				System.IO.StreamReader sr = new
				   System.IO.StreamReader(openFileDialog1.FileName);

				_xmlInput = sr.ReadToEnd();
				sr.Close();
			}

			ClassDataProducerV3 classData = new ClassDataProducerV3();
			classData.inputXml = _xmlInput;
			classData.processDrugs();
			rtbOutput.Clear();

			rtbOutput.AppendText("Classes Processed: " + classData.classesProcessedCount.ToString());
			rtbOutput.AppendText(System.Environment.NewLine);
			rtbOutput.AppendText("Classes Added: " + classData.classesAddedToListCount.ToString());
			rtbOutput.AppendText(System.Environment.NewLine);
			rtbOutput.AppendText("No of drugs processed: " + classData.drugsProcessedCount.ToString());
			rtbOutput.AppendText(System.Environment.NewLine);
			rtbOutput.AppendText("No of drugs Added: " + classData.drugsAddedToListCount.ToString());
			rtbOutput.AppendText(System.Environment.NewLine);
			rtbOutput.AppendText(System.Environment.NewLine);

			//output json
			rtbOutput.AppendText(classData.displayJason);

		}

		private void bntJsonDeser_Click(object sender, EventArgs e)
		{

		}
	}
}
