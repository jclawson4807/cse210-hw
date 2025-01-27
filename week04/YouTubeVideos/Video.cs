using System;

public class Video
{
    private string _title;
    private string _author;
    private int _length;

    private List<Comment> _commentList = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(string nameOfCommentAuthor, string commentText)
    {
        Comment comment = new Comment(nameOfCommentAuthor, commentText);

        _commentList.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _commentList.Count;
    }

    public void DisplayVideoInformation()
    {
        Console.WriteLine($"Video Title: {_title}\n\tAuthor: {_author}\n\tLength (seconds) {_length}\n");

        if (_commentList.Count > 0)
        {
            Console.Write($"{_commentList.Count} Comment");

            if (_commentList.Count > 1)
            {
                Console.Write("s");
            }

            Console.Write(":\n");

            foreach (Comment comment in _commentList)
            {
                comment.DisplayComment();
            }
        }
        else
        {
            Console.WriteLine("No comments found for this video.");     
        }

        Console.WriteLine("\n");
    }
}