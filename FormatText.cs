namespace AssignmentHyphen;


public class FormatText
{
    private string updatedText = "";
    private string currentLine = "";
    private int textWidth;
    private int looseLineLength;
    private int currentChar;


    public string WrapAndHyphenate(string text, int textWidth, int looseLineLength)
    {
        this.textWidth = textWidth;
        this.looseLineLength = looseLineLength;

        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            GetCurrentChar(word);

            if (FitsInCurrentLine())
                AddWord(word);

            else if (ShouldUseHyphen(word))
                ApplyHyphen(word);

            else
                MoveWordToNextLine(word);
        }

        updatedText += currentLine;
        return updatedText;
    }


    private bool FitsInCurrentLine()
    {
        return currentChar <= textWidth + looseLineLength;
    }

    private void AddWord(string word, string lineBreak = "")
    {
        currentLine += (currentLine.Length == 0 ? "" : " ") + word + lineBreak;
    }

    private void GetCurrentChar(string word)
    {
        currentChar = currentLine.Length + word.Length + (currentLine.Length > 0 ? 1 : 0);
    }

    private bool ShouldUseHyphen(string word, int minWordLength = 6, int minLettersAfterHyphen = 2, int minLettersBeforeHyphen = 2)
    {
        if (!char.IsLetter(word[^1]) && minLettersAfterHyphen <= 2)
            minLettersAfterHyphen++;
        if (!char.IsLetter(word[0]) && minLettersBeforeHyphen <= 2)
            minLettersBeforeHyphen++;

        int availableBeforeHyphen = textWidth - currentLine.Length - 1 + looseLineLength;
        int availableAfterHyphen = currentChar - textWidth - looseLineLength;

        return word.Length >= minWordLength &&
        availableBeforeHyphen >= minLettersBeforeHyphen &&
        availableAfterHyphen >= minLettersAfterHyphen;
    }

    private void ApplyHyphen(string word)
    {
        int splitIndex = textWidth - currentLine.Length - 1 + looseLineLength;
        if (splitIndex > 0)
        {
            currentLine += " " + word.Substring(0, splitIndex) + "-";
            updatedText += currentLine + "\n";
            currentLine = word.Substring(splitIndex);
        }
    }

    private void MoveWordToNextLine(string word)
    {
        updatedText += currentLine + "\n";
        currentLine = word;
    }

}
