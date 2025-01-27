using System;

class Program
{
    static private List<Video> _videoList = new List<Video>();

    static void PopulateVideoList()
    {
        Video video1 = new Video("\"I Am He\" | Jeffrey R. Holland | October 2024 General Conference", "President Jeffrey R. Holland", 923);
        video1.AddComment("@daveellis6149", "What a blessing it is to still have him in this world.");
        video1.AddComment("@grantkingston4968", "I'm a teenager. I attended this meeting Sunday morning and was blessed to hear my most favorite apostle speak. Elder Holland, you may not ever read this, ever hear of this, but I'd like you to know your words bring me great comfort, but more, have saved my life. I love you elder, and I can't one day wait to greet you in heaven.❤");
        video1.AddComment("@normanharris6023", "For decades, we have watched these prophets and apostles grow frail in service to their God and their fellow man.  We have witnessed them live out their lives in our service, and when their call to return to His presence came, we see equally competent and kind servants get called and continue in like fashion.  Truly grateful for their Christlike examples, their love and their diligence in dedicating their lives to a purpose singular to bringing to pass the immortality and eternal life of man.  Thank you Elder Holland for sharing your love of God....!!");
        video1.AddComment("@TheFeyDM2926", "I love to listening to the talks of Jeffery R. Holland. He always reminds me to stick it through with Christ until the end.");

        _videoList.Add(video1);

        Video video2 = new Video("In the Space of Not Many Years | David A. Bednar | October 2024 General Conference", "Elder David A. Bednar", 976);
        video2.AddComment("@CherylEdvalson", "His promise at the end is stunning!  Truth from a prophets mouth.  The scriptures truly are for our day!");
        video2.AddComment("@gwenynmel5682", "This whole Conference was amazing. The world is in need of these wise men and women of faith.");
        video2.AddComment("@ann-mariejensen2623", "How can you not love a revival of that great President Benson talk on pride? I am thankful for living prophets, seers, and revelators. Sincere thanks to Elder Bednar.");
        video2.AddComment("@kimhaughton3771", "This was so powerful!!!  Third time listening. A warning to us all. What i heard in my heart was: Read the words of Helamen and see a description of OUR day in black and white. Come to a knowledge of our awful situation and be grateful  for this warning before it is too late. I pray for the strength to heed that profound and timely warning. Thank you, Elder Bednar, for reminding me that I must be on guard continually. Thank you for quoting President Benson for whom I have great admiration. ❤");

        _videoList.Add(video2);

        Video video3 = new Video("The Lord Jesus Christ Will Come Again | October 2024 General Conference", "President Russell M. Nelson", 14, 49);
        video3.AddComment("@christiangibbs8534", "I can't help but notice that every conference, he announces a temple in Mexico. What a great blessing for that country.");
        video3.AddComment("@audreywaite9022", "This talk by our dear prophet really hit me. The Savior is coming sooner than we thought. It's go time, everyone!!!");
        video3.AddComment("@josephgelwix6788", "The servants of the Lord are telling us quite plainly. The Savior will indeed come again, and how I love my Savior!");
        video3.AddComment("@KizzFaithHurdon", "This message stirred my soul and I am in tears, The Saviour will come again🥰 Wonderful, Counsellor, The mighty God, The Everlasting Father, The Prince of Peace.");

        _videoList.Add(video3);

        Video video4 = new Video("Live Up to Your Privileges | Emily Belle Freeman | October 2024 General Conference", "Sister Emily Belle Freeman", 11, 45);
        video4.AddComment("@heidihales497", "This was my favorite talk of the whole conference. Thank you Sister Freeman!");
        video4.AddComment("@markwoods3210", "Emma had a path to follow, we all have the covenant path to follow. if we are living up to our privileges, the path, it's so much easier to see.");
        video4.AddComment("@martinwesterlund957", "This talk hit hard for me and realized that I need to look at my priesthood ordinances more deeply, more spiritually, more prayerfully and that I need to be a better and more  faithful priesthood holder and do that personal inventory on myself.");
        video4.AddComment("@recursosyvaloreshumanos9582", "I want to Live Up to my  Privileges ..........thank you sister  Emily Belle... i want the power or holliness to be mmanifested in my daily life, in my decisions in my life !!!!");

        _videoList.Add(video4);
    }

    static void Main(string[] args)
    {
        PopulateVideoList();

        foreach (Video video in _videoList)
        {
            video.DisplayVideoInformation();
        }
    }
}