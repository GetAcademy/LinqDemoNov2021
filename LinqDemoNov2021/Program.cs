using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LinqDemoNov2021
{
    class Program
    {
        static void Main(string[] args)
        {
            /* LINQ bygger
             *  - Extension methods
             *  - Builder Pattern
             *  - interface IQueryable og IEnumerable
             *
             * "Paste JSON as classes"
             *
             * LINQ
             *  - Where() - .filter() i JavaScript
             *  - Select() - .map() i JavaScript
             */

            var json = "{\"total\":20,\"result\":[{\"categories\":[],\"created_at\":\"2020-01-05 13:42:19.104863\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"Zd3ssHgRRFSShLYCygFwPw\",\"updated_at\":\"2020-01-05 13:42:19.104863\",\"url\":\"https://api.chucknorris.io/jokes/Zd3ssHgRRFSShLYCygFwPw\",\"value\":\"Chuck Norris can ski on lava and roast marshmallows on snow.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:19.897976\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"p1HYJoQ3T66Ut1gBxGW7UA\",\"updated_at\":\"2020-01-05 13:42:19.897976\",\"url\":\"https://api.chucknorris.io/jokes/p1HYJoQ3T66Ut1gBxGW7UA\",\"value\":\"If you dare to eat a bowl Chuck Norris' homemade Texas Hot Chile and later take a dump, you'll need to wipe your ass with a snow cone.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:19.897976\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"H-uRrPnWSoOJ-0hItqL2cw\",\"updated_at\":\"2020-01-05 13:42:19.897976\",\"url\":\"https://api.chucknorris.io/jokes/H-uRrPnWSoOJ-0hItqL2cw\",\"value\":\"Any man can make yellow snow. Chuck Norris can make brown snow.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:20.262289\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"MLfWSdKJQOa2FCxD_KAsFA\",\"updated_at\":\"2020-01-05 13:42:20.262289\",\"url\":\"https://api.chucknorris.io/jokes/MLfWSdKJQOa2FCxD_KAsFA\",\"value\":\"Some kids piss their name in the snow. Chuck Norris can piss his name into concrete.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:20.568859\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"o_H6N80TRh2WUacJ_nIFzg\",\"updated_at\":\"2020-01-05 13:42:20.568859\",\"url\":\"https://api.chucknorris.io/jokes/o_H6N80TRh2WUacJ_nIFzg\",\"value\":\"When Sir Edmund Hillary first climbed to the summit of Everest, he saw empty beer cans, condoms and cigar butts strewn around, plus a giant snow angel and the words 'CHUCK NORRIS BEAT YOU, BITCH' written in urine in the snow.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:20.568859\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"qF6bzfl3QF6i-hik0dhnng\",\"updated_at\":\"2020-01-05 13:42:20.568859\",\"url\":\"https://api.chucknorris.io/jokes/qF6bzfl3QF6i-hik0dhnng\",\"value\":\"Chuck Norris goes bob-sledding in a coffin. It's the only time he can get some private time on the snow fields to have his threesomes.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:20.841843\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"sXNHPAVVS--P9AdxvG2Vwg\",\"updated_at\":\"2020-01-05 13:42:20.841843\",\"url\":\"https://api.chucknorris.io/jokes/sXNHPAVVS--P9AdxvG2Vwg\",\"value\":\"Chuck Norris pee'd his name in the snow at Aspen. He was standing in Dallas.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:21.795084\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"HhkRR4NkT1yE-Q0bwWLhWA\",\"updated_at\":\"2020-01-05 13:42:21.795084\",\"url\":\"https://api.chucknorris.io/jokes/HhkRR4NkT1yE-Q0bwWLhWA\",\"value\":\"Chuck Norris loves making cocaine snow angels on the floors of his castles.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:23.880601\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"a92anp-4SVeQZxg-CmNhEA\",\"updated_at\":\"2020-01-05 13:42:23.880601\",\"url\":\"https://api.chucknorris.io/jokes/a92anp-4SVeQZxg-CmNhEA\",\"value\":\"Chuck Norris can make a snowman out of raindrops.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:24.142371\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"1IcYicBPRhqM5-AXUbR9wg\",\"updated_at\":\"2020-01-05 13:42:24.142371\",\"url\":\"https://api.chucknorris.io/jokes/1IcYicBPRhqM5-AXUbR9wg\",\"value\":\"Antarctica was made by sand everywhere.Then Chuck Norris used a flamethrower to turn it into ice. Finally it got so cold that it started snowing. And its also how winter was made.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:24.40636\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"GB4Yr75TTFmxHhU_Wpjerw\",\"updated_at\":\"2020-01-05 13:42:24.40636\",\"url\":\"https://api.chucknorris.io/jokes/GB4Yr75TTFmxHhU_Wpjerw\",\"value\":\"Chuck Norris doesn't snowboard the mountain just moves beneath Chuck Norris\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:25.099703\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"GfTqByv2R0GPvWgGxORoYw\",\"updated_at\":\"2020-01-05 13:42:25.099703\",\"url\":\"https://api.chucknorris.io/jokes/GfTqByv2R0GPvWgGxORoYw\",\"value\":\"Not only can Chuck Norris build a snowman out of rain, he can also drown a fish.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:25.099703\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"qWBbR7_sQXy2ZSjUzmQspA\",\"updated_at\":\"2020-01-05 13:42:25.099703\",\"url\":\"https://api.chucknorris.io/jokes/qWBbR7_sQXy2ZSjUzmQspA\",\"value\":\"Chuck Norris once made a snowman....out of rain.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:25.628594\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"GMkUENKvSySHbWdUzh8kvA\",\"updated_at\":\"2020-01-05 13:42:25.628594\",\"url\":\"https://api.chucknorris.io/jokes/GMkUENKvSySHbWdUzh8kvA\",\"value\":\"Chuck Norris can build a snowman with rain\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:25.905626\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"btiSP8QlQCq7Ma2RJUFxng\",\"updated_at\":\"2020-01-05 13:42:25.905626\",\"url\":\"https://api.chucknorris.io/jokes/btiSP8QlQCq7Ma2RJUFxng\",\"value\":\"kids piss there name n snow Chuck Norris pisses his name in concrete\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:26.194739\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"kbQpRPkTQumrSKEfkBoCYg\",\"updated_at\":\"2020-01-05 13:42:26.194739\",\"url\":\"https://api.chucknorris.io/jokes/kbQpRPkTQumrSKEfkBoCYg\",\"value\":\"Chuck Norris doesn't want to build a snowman.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:26.766831\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"KKlC7IqwQBOjdJaZrKREZg\",\"updated_at\":\"2020-01-05 13:42:26.766831\",\"url\":\"https://api.chucknorris.io/jokes/KKlC7IqwQBOjdJaZrKREZg\",\"value\":\"The reason the last Ice Age ended was because Chuck Norris had gotten bored with all the snow and ice, and yawned, melting all the glaciers.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:27.496799\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"Q1KcpYvbS3Cp5UFR52G5yA\",\"updated_at\":\"2020-01-05 13:42:27.496799\",\"url\":\"https://api.chucknorris.io/jokes/Q1KcpYvbS3Cp5UFR52G5yA\",\"value\":\"Grandma got run over by a reindeer. Then Chuck Norris mowed her down with his snowmobile and finished her off.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:29.296379\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"jX41J59HTIyRg0GYBbk6EA\",\"updated_at\":\"2020-01-05 13:42:29.296379\",\"url\":\"https://api.chucknorris.io/jokes/jX41J59HTIyRg0GYBbk6EA\",\"value\":\"Chuck Norris' homemade Texas chili is so hot that if you ate a bowl of it this evening, you would wish that you had a strawberry snow cone to wipe your ass with tomorrow morning.\"},{\"categories\":[],\"created_at\":\"2020-01-05 13:42:29.569033\",\"icon_url\":\"https://assets.chucknorris.host/img/avatar/chuck-norris.png\",\"id\":\"eBKxNNFqQTCHBgOn4v10eg\",\"updated_at\":\"2020-01-05 13:42:29.569033\",\"url\":\"https://api.chucknorris.io/jokes/eBKxNNFqQTCHBgOn4v10eg\",\"value\":\"The Inuit have over a 100 words for snow but only two for fear.. Chuck Norris.\"}]}";

            var pageSize = 10;
            var pageIndex = 5;

            var jokeResultSet = JsonSerializer.Deserialize<JokeResultSet>(json);
            var jokeObjects = jokeResultSet.result;
            //var jokeStrings = jokeObjects.Select(SelectJokeValue);
            var jokeStrings = jokeObjects
                .Where(jObj=>char.IsLower(jObj.id[0]))
                .Select(jObj => $"{jObj.value} ({jObj.id})")
                .Where(jStr => jStr.Length < Console.WindowWidth)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToArray();

            var myJoke = jokeObjects.First(jObj => jObj.id == "Q1KcpYvbS3Cp5UFR52G5yA");
            var myJoke2 = jokeObjects.FirstOrDefault(jObj => jObj.id == "Q1KcpYvbS3Cp5UFR52G5yA");
            var myJoke3 = jokeObjects.First();
            var myJoke4 = jokeObjects.Last();

            var myJokex = GetJokeById(jokeObjects);
            if(myJokex==null) Console.WriteLine("Error");

            Console.WriteLine(myJokex.value);

            var jokeStrings2= new List<string>();
            foreach (var jObj in jokeObjects)
            {
                if (char.IsLower(jObj.id[0])&& jObj.value.Length < Console.WindowWidth)
                {
                    jokeStrings2.Add($"{jObj.value} ({jObj.id})");
                }
            }

            var sum = Enumerable.Range(1, 999)
                .Where(n => n % 3 == 0 || n % 5 == 0)
                .Sum();
            Console.WriteLine(sum);

            /*
             * var result = data
             *      .Where(step1)
             *      .Where(step2)
             *      .Select(step3)
             */


            Console.WriteLine(string.Join('\n', jokeStrings));

            /*
                const fruits = ["Banana", "Orange", "Apple", "Mango"];
                let hasMango = fruits.includes("Mango");             
             */
            var fruits = new[] { "Banana", "Orange", "Apple", "Mango" };
            var hasMango1 = fruits.Contains("Mango");
            var hasMango2 = fruits.Any(f=>f=="Mango");
            var allIsMango = fruits.All(f=>f=="Mango");

            //foreach (var joke in jokeStrings)
            //{
            //    Console.WriteLine(joke);
            //}

            //BuilderPatternDemo();
            //ExtensionMethodDemo();
        }

        private static Joke GetJokeById(Joke[] jokeObjects)
        {
            Joke myJokex = null;
            foreach (var jokeObject in jokeObjects)
            {
                if (jokeObject.id == "Q1KcpYvbS3Cp5UFR52G5yA")
                {
                    myJokex = jokeObject;
                }
            }

            return myJokex;
        }

        private static string SelectJokeValue(Joke joke)
        {
            return joke.value;
        }

        private static void BuilderPatternDemo()
        {
            //var htmlBuilder = new HtmlBuilder();
            //htmlBuilder.H1("Overskrift");
            //htmlBuilder.P("Bla bla bla");
            //htmlBuilder.H2("Overskrift");
            //htmlBuilder.P("Bla bla bla");
            //var html = htmlBuilder.GetHtml();

            var html = new HtmlBuilder()
                .H1("Overskrift")
                .P("Bla bla bla")
                .H2("Overskrift")
                .P("Bla bla bla");
            Console.WriteLine(html);

            var t1 = "A" + "B";

            //string t2;
            //var sb = new StringBuilder();
            //sb.Append("A");
            //sb.Append("B");
            //t2 = sb.ToString();

            var t2 = new StringBuilder()
                .Append("A")
                .Append("B")
                .ToString();
        }

        private static void ExtensionMethodDemo()
        {
            var s = "Terje";
            var index = s.IndexOf('T');
            s = s.SpaceIt();
            s = StringExtensions.SpaceIt(s);
            s.Reverse();
            //s = SpaceIt(s);
        }
    }
}
