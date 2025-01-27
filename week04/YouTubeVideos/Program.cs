using System;

class Program
{
    static private List<Video> _videoList = new List<Video>();

    static void PopulateVideoList()
    {
        Video video1 = new Video("\"I Am He\" | Jeffrey R. Holland | October 2024 General Conference", "President Jeffrey R. Holland", 923);
        video1.AddComment("@daveellis6149", "What a blessing it is to still have him in this world.");
        video1.AddComment("@grantkingston4968", "I’m a teenager. I attended this meeting Sunday morning and was blessed to hear my most favorite apostle speak. Elder Holland, you may not ever read this, ever hear of this, but I’d like you to know your words bring me great comfort, but more, have saved my life. I love you elder, and I can’t one day wait to greet you in heaven.❤");
        video1.AddComment("@normanharris6023", "For decades, we have watched these prophets and apostles grow frail in service to their God and their fellow man.  We have witnessed them live out their lives in our service, and when their call to return to His presence came, we see equally competent and kind servants get called and continue in like fashion.  Truly grateful for their Christlike examples, their love and their diligence in dedicating their lives to a purpose singular to bringing to pass the immortality and eternal life of man.  Thank you Elder Holland for sharing your love of God....!!");
        video1.AddComment("@TheFeyDM2926", "I love to listening to the talks of Jeffery R. Holland. He always reminds me to stick it through with Christ until the end.");

        _videoList.Add(video1);

        
    }

    static void Main(string[] args)
    {
        
    }
}