namespace wepAppPractice.Repository
{
    public class DemoTestService : IDemo
    {
        public string GetData()
        {
            return "I came from Demo test services";
            //throw new System.NotImplementedException();
        }
    }
}
