namespace MauiTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            this.CollectionView1.ItemsSource = GetNewData();
            UpdateMemory(1);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            this.CollectionView2.ItemsSource = GetNewData();
            UpdateMemory(2);

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            this.CollectionView3.ItemsSource = GetNewData();
            UpdateMemory(3);
        }

        int id;
        List<DataModel> GetNewData()
        {
            List<DataModel> data = new();
            for (int i = 0; i < 50; i++)
            {
                id += 1;
                data.Add(new DataModel() { ID = id, Name = $"Name{id}", Data1 = "data1", Data2 = "data2", Data3 = "data3" });
            }
            return data;
        }

        void UpdateMemory(int testid)
        {
            GC.Collect(3, GCCollectionMode.Forced,true);
            this.LabelMemory.Text = $"Memory {GC.GetTotalMemory(true):N0} after test {testid}"; 
        }
    }

    public class DataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
    }
}