using System;

public class Comment
{
    private string _nameOfCommentAuthor;
    private string _commentText;

    public Comment(string nameOfCommentAuthor, string commentText)
    {
        _nameOfCommentAuthor = nameOfCommentAuthor;
        _commentText = commentText;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"Comment Author: {_nameOfCommentAuthor}\nComment: {_commentText}");
    }
}