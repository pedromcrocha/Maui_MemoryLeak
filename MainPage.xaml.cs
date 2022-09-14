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
            UpdateMemoryAsync(1);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            this.CollectionView2.ItemsSource = GetNewData();
            UpdateMemoryAsync(2);
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            this.CollectionView3.ItemsSource = GetNewData();
            UpdateMemoryAsync(3);
        }

        int id;
        List<DataModel> GetNewData()
        {
            List<DataModel> data = new();
            for (int i = 0; i < 5; i++)
            {
                id += 1;
                data.Add(new DataModel() { ID = id, Name = $"Name{id}", Data1 = "data1", Data2 = "data2", Data3 = "data3" });
            }
            return data;
        }

        async Task  UpdateMemoryAsync(int testid)
        {
            await Task.Delay(500);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            this.LabelMemory.Text = $"Memory {GC.GetTotalMemory(true):N0} after test {testid}";

            this.LabelAlive.Text = $"Objects alive {Refs.GetAliveCount()}";
            Refs.Print();
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