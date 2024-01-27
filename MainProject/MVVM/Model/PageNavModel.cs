namespace MainProject.MVVM.Model;

public class PageNavModel
{
    public string Name { get; set; }
    public string ImageSource { get; set; }
    public PageNavModel()
    {
     
    }
    public PageNavModel(string name, string image)
    {
        Name = name;
        ImageSource = image;
    }
}