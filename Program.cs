
string text = "Nick sat against the wall of the church where they had dragged him to be clear of machine gun fire in the street. Both legs stuck out awkwardly. He had been hit in the spine. His face was sweaty and dirty. The sun shone on his face. The day was very hot. Rinaldi, big backed, his equipment sprawling, lay face downward against the wall. Nick looked straight ahead brilliantly. The pink wall of the house opposite had fallen out from the roof, and an iron bedstead hung twisted toward the street. Two Austrian dead lay in the rubble in the shade of the house. Up the street were other dead. Things were getting forward in the town. It was going well. Stretcher bearers would be along any time now. Nick turned his head carefully and looked down at Rinaldi. “Senta Rinaldi. Senta. You and me we’ve made a separate peace.” Rinaldi lay still in the sun breathing with difficulty. “Not patriots.” Nick turned his head carefully away smiling sweatily. Rinaldi was a disappointing audience. While the bombardment was knocking the trench to pieces at Fossalta, he lay very flat and sweated and prayed oh jesus christ get me out of here. Dear jesus please get me out. Christ please please please christ. If you’ll only keep me from getting killed I’ll do anything you say. I believe in you and I’ll tell everyone in the world that you are the only thing that matters. Please please dear jesus. The shelling moved further up the line. We went to work on the trench and in the morning the sun came up and the day was hot and muggy and cheerful and quiet. The next night back at Mestre he did not tell the girl he went upstairs with at the Villa Rossa about Jesus. And he never told anybody.";
string updatedText = "";
string currentLine = "";
int textWidth = 50;
int looseLineLength = 1;
int currentChar = 0;

Console.WriteLine(FormatText(text, textWidth));

string FormatText(string text, int textWidth)
{
    string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);


    foreach (string word in words)
    {
        int currentChar = currentLine.Length + word.Length + (currentLine.Length > 0 ? 1 : 0);

        if (currentChar < textWidth)
        {
            currentLine += (currentLine.Length == 0 ? "" : " ") + word;
        }
        else
        {
            if (currentChar > textWidth)
            {
                if (currentChar - textWidth <= looseLineLength)
                {
                    currentLine += " " + word + "\n";
                    updatedText += currentLine;
                    currentLine = "";
                }
                else if (needHyphen(word))
                {
                    SetHyphen(word);
                }
                else
                {
                    updatedText += currentLine + "\n";
                    currentLine = word;
                }
            }
            else
            {
                updatedText += currentLine + "\n";
                currentLine = word;
            }
        }
    }

    if (!string.IsNullOrEmpty(currentLine))
    {
        updatedText += currentLine;
    }

    return updatedText;
}
bool needHyphen(string word)
{
    return word.Length >= 6 && currentChar - textWidth + looseLineLength >= 3 && textWidth - (currentChar - word.Length) > 2 && char.IsLetter(word[^1]);
}

void SetHyphen(string word)
{
    int splitIndex = textWidth - currentLine.Length - 2 + looseLineLength;
    if (splitIndex > 0)
    {
        currentLine += (currentLine.Length > 0 ? " " : "") + word.Substring(0, splitIndex) + "-";
        updatedText += currentLine + "\n";
        currentLine = word.Substring(splitIndex);
    }
}

