using AssignmentHyphen;

string text = "Nick sat against the wall of the church where they had dragged him to be clear of machine gun fire in the street. Both legs stuck out awkwardly. He had been hit in the spine. His face was sweaty and dirty. The sun shone on his face. The day was very hot. Rinaldi, big backed, his equipment sprawling, lay face downward against the wall. Nick looked straight ahead brilliantly. The pink wall of the house opposite had fallen out from the roof, and an iron bedstead hung twisted toward the street. Two Austrian dead lay in the rubble in the shade of the house. Up the street were other dead. Things were getting forward in the town. It was going well. Stretcher bearers would be along any time now. Nick turned his head carefully and looked down at Rinaldi. “Senta Rinaldi. Senta. You and me we’ve made a separate peace.” Rinaldi lay still in the sun breathing with difficulty. “Not patriots.” Nick turned his head carefully away smiling sweatily. Rinaldi was a disappointing audience. While the bombardment was knocking the trench to pieces at Fossalta, he lay very flat and sweated and prayed oh jesus christ get me out of here. Dear jesus please get me out. Christ please please please christ. If you’ll only keep me from getting killed I’ll do anything you say. I believe in you and I’ll tell everyone in the world that you are the only thing that matters. Please please dear jesus. The shelling moved further up the line. We went to work on the trench and in the morning the sun came up and the day was hot and muggy and cheerful and quiet. The next night back at Mestre he did not tell the girl he went upstairs with at the Villa Rossa about Jesus. And he never told anybody.";


FormatText TextFormat = new();

Console.WriteLine(TextFormat.WrapAndHyphenate(text, 50, 3));





