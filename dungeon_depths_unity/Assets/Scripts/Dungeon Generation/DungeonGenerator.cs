using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Scripts
{
    public static class DungeonGenerator
    {
        public enum DUNGEON_TYPE { FOREST, CAVE };
        
        //private static string line_clear = "\r" + new string(' ', Console.WindowWidth - 1) + "\r";
        private static string line_clear = "\r";

        private static Random r;
        private static int seed = 0;
        private static bool consoleOut = false;

        private static DUNGEON_TYPE type = DUNGEON_TYPE.FOREST;

        //Forest
        private static int mapWidth = 60;
        private static int mapHeight = 60;
        private static int minRooms = 10;
        private static int maxRooms = 13;
        private static int minMinRoomWidth = 5;
        private static int maxMinRoomWidth = 10;
        private static int minMaxRoomWidth = 10;
        private static int maxMaxRoomWidth = 20;
        private static int minMinRoomHeight = 5;
        private static int maxMinRoomHeight = 10;
        private static int minMaxRoomHeight = 10;
        private static int maxMaxRoomHeight = 20;
        private static double waviness = 1;
        private static bool allowTouching = true;

        //Cave
        private static double fillAmt = 0.4;
        private static double weightedTowardCenter = 0;
        private static double weightedTowardPreviousDirection = 0.2;
        private static int cleanMax = 10;

        public static void init(int seed = 0, bool consoleOut = false, int mapWidth = 60, int mapHeight = 60, int minRooms = 10, int maxRooms = 13, int minMinRoomWidth = 5, int maxMinRoomWidth = 10, int minMaxRoomWidth = 10, int maxMaxRoomWidth = 20, int minMinRoomHeight = 5, int maxMinRoomHeight = 10, int minMaxRoomHeight = 10, int maxMaxRoomHeight = 20, double waviness = 1, bool allowTouching = true, DUNGEON_TYPE dungeon_type = DUNGEON_TYPE.FOREST, double fillAmt = 0.4, double weightedTowardCenter = 0, double weightedTowardPreviousDirection = .2, int cleanMax = 10)
        {
            DungeonGenerator.seed = seed;
            DungeonGenerator.consoleOut = consoleOut;
            DungeonGenerator.mapWidth = mapWidth;
            DungeonGenerator.mapHeight = mapHeight;
            DungeonGenerator.minRooms = minRooms;
            DungeonGenerator.maxRooms = maxRooms;
            DungeonGenerator.minMinRoomWidth = minMinRoomWidth;
            DungeonGenerator.maxMinRoomWidth = maxMinRoomWidth;
            DungeonGenerator.minMaxRoomWidth = minMaxRoomWidth;
            DungeonGenerator.maxMaxRoomWidth = maxMaxRoomWidth;
            DungeonGenerator.minMinRoomHeight = minMinRoomHeight;
            DungeonGenerator.maxMinRoomHeight = maxMinRoomHeight;
            DungeonGenerator.minMaxRoomHeight = minMaxRoomHeight;
            DungeonGenerator.maxMaxRoomHeight = maxMaxRoomHeight;
            DungeonGenerator.waviness = waviness;
            DungeonGenerator.allowTouching = allowTouching;
            DungeonGenerator.type = dungeon_type;
            DungeonGenerator.fillAmt = fillAmt;
            DungeonGenerator.weightedTowardCenter = weightedTowardCenter;
            DungeonGenerator.weightedTowardPreviousDirection = weightedTowardPreviousDirection;
            DungeonGenerator.cleanMax = cleanMax;
        }

        public static Tile[,] generate(DUNGEON_TYPE type)
        {
            DungeonGenerator.type = type;
            return generate();
        }

        public static Tile[,] generate()
        {
            r = new Random(seed);

            Tile[,] map = createEmptyMapOfSize(mapWidth, mapHeight);

            if(type == DUNGEON_TYPE.FOREST)
            {
                int rooms = r.Next(minRooms, maxRooms);
                int minWidth = r.Next(minMinRoomWidth, maxMinRoomWidth);
                int maxWidth = r.Next(minMaxRoomWidth, maxMaxRoomWidth);
                int minHeight = r.Next(minMinRoomHeight, maxMinRoomHeight);
                int maxHeight = r.Next(minMaxRoomHeight, maxMaxRoomHeight);
                //double waviness = r.NextDouble();
                //double waviness = waviness;

                if(minWidth > maxWidth)
                {
                    int temp = minWidth;
                    minWidth = maxWidth;
                    maxWidth = temp;
                }
                if(minHeight > maxHeight)
                {
                    int temp = minHeight;
                    minHeight = maxHeight;
                    maxHeight = temp;
                }

                Stopwatch stopwatch = Stopwatch.StartNew();
                if(consoleOut) { Console.WriteLine("Generating Dungeon"); }
                
                generateForestDungeon(map, rooms, minWidth, minHeight, maxWidth, maxHeight, waviness, allowTouching);

                stopwatch.Stop();
                if(consoleOut) { Console.WriteLine("Total: [" + stopwatch.Elapsed + "]"); }
                stopwatch = Stopwatch.StartNew();
                //generateImg(map, "map_r" + rooms + "_mw" + minWidth + "_Mw" + maxWidth + "_mh" + minHeight + "_Mh" + maxHeight + "_w" + waviness +  ".bmp", 10);
                stopwatch.Stop();
                if(consoleOut) { Console.WriteLine("Generated image in [" + stopwatch.Elapsed + "]"); }
                //generateImg(map, "map_" + num + "_real.bmp", 1);
            }
            else if(type == DUNGEON_TYPE.CAVE)
            {
                generateCave(map, fillAmt, weightedTowardCenter, weightedTowardPreviousDirection);
            }

            return map;
        }

        #region Cave Generation
        public static void generateCave(Tile[,] map, double fillPercent = 0.4, double weightedTowardCenter = 0, double weightedTowardPreviousDirection = .2, int cleanMax = 10)
        {
            //Based on:  
            //https://github.com/AtTheMatinee/dungeon-generation/blob/master/dungeonGenerationAlgorithms.py

            //Higher [weightedTowardCenter] tends to bunch up towards edges
            //Lower [weightedTowardPreviousDirection] trends to a more linear path

            int width = map.GetLength(1);
            int height = map.GetLength(0);

            bool[,] level = create2DArrayOfSize<bool>(width, height, false);
            int filledGoal = (int)(height * width * fillPercent);
            int maxIterations;
            try
            {
                maxIterations = checked(2500 * height * width);
            }
            catch(OverflowException e)
            {
                maxIterations = Int32.MaxValue;
            }

            double iterations = Math.Max(maxIterations, width * height * 10);
            double filled = 0;
            char previousDir = '\0';
            int walkX = width / 2;
            int walkY = height / 2;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for(int i = 0; i < maxIterations; i++)
            {
                walk(level, ref walkX, ref walkY, width, height, weightedTowardCenter, weightedTowardPreviousDirection, ref previousDir, ref filled);
                if(filled >= filledGoal)
                {
                    break;
                }
            }
            stopwatch.Stop();
            //Console.WriteLine("Walked in [" + stopwatch.Elapsed + "]");


            //Clean
            stopwatch = Stopwatch.StartNew();
            //For faster cleaning, anything that is deemed to big is turned into "floor" temporarily to prevent rechecking
            //Anything actually cleaned will be cleaned from both
            bool[,] levelCopy = (bool[,])level.Clone();
            if(cleanMax > 0)
            {
                //Preclean the four corners, where you're it's the least likely to have anything that actually needs cleaning 
                //and is most likely to have the outer edge that is to be ignored
                Stopwatch precleanStopwatch = Stopwatch.StartNew();
                clean(levelCopy, 0, 0);
                clean(levelCopy, 0, height - 1);
                clean(levelCopy, width - 1, 0);
                clean(levelCopy, width - 1, height - 1);
                precleanStopwatch.Stop();
                //Console.WriteLine($"Pre clean in {precleanStopwatch.Elapsed}");

                if(height * width > 10000) //I'm arbitrarily saying that over 1 million cells it should be multithreaded
                {
                    int threadCount = Math.Max(1, Environment.ProcessorCount - 1); //Don't use all the CPU. Leave some for the rest of the computer
                    int cellSize = 100;

                    List<Task> tasks = new List<Task>();
                    for(int x = 0; x < width && x + cellSize <= width; x += cellSize)
                    {
                        int myStartX = x;
                        int myEndX = Math.Min(myStartX + cellSize, width);
                        for(int y = 0; y < height; y += cellSize)
                        {
                            int myStartY = y;
                            int myEndY = Math.Min(myStartY + cellSize, height);
                            Task task = new Task(() => cleanCell(level, ref levelCopy, myStartX, myEndX, myStartY, myEndY, cleanMax));
                            tasks.Add(task);
                        }
                    }

                    Task[] threadTasks = new Task[threadCount];
                    Stopwatch[] threadStopwatches = new Stopwatch[threadCount];
                    for(int i = 0; i < threadCount; i++)
                    {
                        //threadTasks.Add(tasks.Dequeue());
                        threadTasks[i] = tasks[0];
                        tasks.RemoveAt(0);
                        threadTasks[i].Start();
                        threadStopwatches[i] = Stopwatch.StartNew();
                    }

                    bool waiting = true;
                    int done = 0;
                    Stopwatch taskTotalStopwatch = Stopwatch.StartNew();
                    while(tasks.Count > 0 && waiting)
                    {
                        int i = Task.WaitAny(threadTasks);
                        Stopwatch threadStopwatch = threadStopwatches[i];
                        threadStopwatch.Stop();

                        if(tasks.Count > 0)
                        {
                            threadTasks[i] = tasks[0];
                            threadTasks[i].Start();
                            tasks.RemoveAt(0);
                            int inProgress = threadTasks.Where(t => t != null).ToList().Count;
                            int inLine = tasks.Count;
                            done++;
                            //double percent = Math.Round(((double)done) / ((double)(inProgress + inLine + done)) * 100, 3);
                            //TimeSpan sinceLast = threadStopwatch.Elapsed;
                            //TimeSpan estimateLeft = (taskTotalStopwatch.Elapsed / (percent / 100)) - taskTotalStopwatch.Elapsed;
                            //Console.WriteLine($"{inLine} vs {done} | {percent}% | {threadStopwatch.Elapsed} // Left: {estimateLeft}");
                        }
                        else
                        {
                            threadTasks[i] = null;
                            waiting = threadTasks.Any(t => t != null);
                        }
                        threadStopwatches[i] = Stopwatch.StartNew();
                    }
                    taskTotalStopwatch.Stop();

                    //Console.WriteLine($"Done in {taskTotalStopwatch.Elapsed}");
                }
                else
                {
                    for(int x = 0; x < width; x++)
                    {
                        for(int y = 0; y < height; y++)
                        {
                            if(!levelCopy[x, y]) //Wall
                            {
                                if(candidateForCleaning(level, x, y, cleanMax))
                                {
                                    clean(level, x, y);
                                }
                                clean(levelCopy, x, y);
                            }
                        }
                    }
                }
            }
            stopwatch.Stop();
            //Console.WriteLine("Cleaned in [" + stopwatch.Elapsed + "]");


            //Translate
            stopwatch = Stopwatch.StartNew();
            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    if(level[x, y])
                    {
                        map[x, y] = new Floor();
                    }
                }
            }
            stopwatch.Stop();
            //Console.WriteLine("Translated in [" + stopwatch.Elapsed + "]");
        }

        private static void walk(bool[,] map, ref int x, ref int y, int width, int height, double weightedTowardCenter, double weightedTowardPreviousDirection, ref char previousDir, ref double filled)
        {
            double north = 1.0;
            double south = 1.0;
            double east = 1.0;
            double west = 1.0;

            if(x < width * 0.25) //position is at far left side of map
            {
                east += weightedTowardCenter;
            }
            else if(x > width * 0.75) //position is at far right side of map
            {
                west += weightedTowardCenter;
            }

            if(y < height * 0.25) //position is at the top of the map
            {
                south += weightedTowardCenter;
            }
            else if(y > height * 0.75) //position is at the bottom of the map
            {
                north += weightedTowardCenter;
            }

            switch(previousDir)
            {
                case 'n':
                    north += weightedTowardPreviousDirection;
                    break;
                case 'e':
                    east += weightedTowardPreviousDirection;
                    break;
                case 's':
                    south += weightedTowardPreviousDirection;
                    break;
                case 'w':
                    west += weightedTowardPreviousDirection;
                    break;
            }

            //Normalize
            double total = north + south + east + west;
            north /= total;
            south /= total;
            east /= total;
            west /= total;

            int dx = 0;
            int dy = 0;
            char chosenDir = '\0';
            //Choose
            double choice = r.NextDouble();
            if(choice < north && choice >= 0)
            {
                dy = 1;
                chosenDir = 'n';
            }
            else if(choice < (north + south) && choice >= north)
            {
                dy = -1;
                chosenDir = 's';
            }
            else if(choice < (north + south + east) && choice >= (north + south))
            {
                dx = 1;
                chosenDir = 'e';
            }
            else
            {
                dx = -1;
                chosenDir = 'w';
            }

            //Walking to a valid location
            int newX = x + dx;
            int newY = y + dy;
            if(newX >= 0 && newX < width && newY >= 0 && newY < height)
            {
                x = newX;
                y = newY;
                if(!map[x, y])
                {
                    map[x, y] = true;
                    filled++;
                }
                previousDir = chosenDir;
            }
        }

        private static bool candidateForCleaning(bool[,] map, int x, int y, int cleanMax)
        {
            bool[,] tempMap = (bool[,])map.Clone();
            int cleanedCount = 1;

            if(cleanedCount > cleanMax) { return false; }
            if(tempMap[x, y]) { return false; } //If the root is already cleaned then it's obvious not a candidate for cleaning

            tempMap[x, y] = true;
            Queue<Point> Q = new Queue<Point>();
            Q.Enqueue(new Point(x, y));

            while(Q.Count > 0 && cleanedCount < cleanMax)
            {
                //Console.WriteLine("Q#: " + Q.Count);
                Point n = Q.Dequeue();
                if(n.x + 1 < tempMap.GetLength(0) && !tempMap[n.x + 1, n.y])
                {
                    tempMap[n.x + 1, n.y] = true;
                    cleanedCount++;
                    Q.Enqueue(new Point(n.x + 1, n.y));
                }
                if(n.x - 1 >= 0 && !tempMap[n.x - 1, n.y])
                {
                    tempMap[n.x - 1, n.y] = true;
                    cleanedCount++;
                    Q.Enqueue(new Point(n.x - 1, n.y));
                }
                if(n.y + 1 < tempMap.GetLength(1) && !tempMap[n.x, n.y + 1])
                {
                    tempMap[n.x, n.y + 1] = true;
                    cleanedCount++;
                    Q.Enqueue(new Point(n.x, n.y + 1));
                }
                if(n.y - 1 >= 0 && !tempMap[n.x, n.y - 1])
                {
                    tempMap[n.x, n.y - 1] = true;
                    cleanedCount++;
                    Q.Enqueue(new Point(n.x, n.y - 1));
                }
            }

            return Q.Count == 0;
        }

        private static void clean(bool[,] map, int x, int y)
        {
            if(map[x, y]) { return; }
            map[x, y] = true;
            Queue<Point> Q = new Queue<Point>();
            Q.Enqueue(new Point(x, y));

            int width = map.GetLength(1);
            int height = map.GetLength(0);

            while(Q.Count > 0)
            {
                //Console.WriteLine("Q#: " + Q.Count);
                Point n = Q.Dequeue();
                if(n.x + 1 < width && !map[n.x + 1, n.y])
                {
                    map[n.x + 1, n.y] = true;
                    Q.Enqueue(new Point(n.x + 1, n.y));
                }
                if(n.x - 1 >= 0 && !map[n.x - 1, n.y])
                {
                    map[n.x - 1, n.y] = true;
                    Q.Enqueue(new Point(n.x - 1, n.y));
                }
                if(n.y + 1 < height && !map[n.x, n.y + 1])
                {
                    map[n.x, n.y + 1] = true;
                    Q.Enqueue(new Point(n.x, n.y + 1));
                }
                if(n.y - 1 >= 0 && !map[n.x, n.y - 1])
                {
                    map[n.x, n.y - 1] = true;
                    Q.Enqueue(new Point(n.x, n.y - 1));
                }
            }
        }

        private static void cleanCell(in bool[,] real, ref bool[,] precleaned, in int startX, in int endX, in int startY, in int endY, in int cleanMax)
        {
            for(int cleanX = startX; cleanX < endX; cleanX++)
            {
                for(int cleanY = startY; cleanY < endY; cleanY++)
                {
                    if(!precleaned[cleanX, cleanY])
                    {
                        if(candidateForCleaning(precleaned, cleanX, cleanY, cleanMax))
                        {
                            clean(real, cleanX, cleanY);
                        }
                        clean(precleaned, cleanX, cleanY);
                    }
                }
            }
        }

        #endregion

        #region Forest Generation
        private static void generateForestDungeon(Tile[,] map, int roomCount, int minWidth, int minHeight, int maxWidth, int maxHeight, double straightness, bool allowTouching)
        {
            int width = map.GetLength(0);
            int height = map.GetLength(1);

            List<Room> rooms = new List<Room>();

            int fails = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            do
            {
                int failedAttempts = -1;
                Room newRoom = null;
                do
                {
                    failedAttempts++;

                    if(failedAttempts > 2500)
                    {
                        if(consoleOut) { Console.WriteLine(""); }
                        if(fails > 10)
                        {
                            if(consoleOut) { Console.WriteLine("Parameters had way too many rooms. Trying parameters again with 10 less room (" + roomCount + ")"); }
                            roomCount -= 10;
                        }
                        else
                        {
                            roomCount--;
                            if(consoleOut) { Console.WriteLine("Trying parameters again with 1 less room (" + roomCount + ")"); }
                        }
                        rooms.Clear();
                        fails++;
                        newRoom = null;
                        break;
                    }
                    
                    int w = r.Next(minWidth, maxWidth);
                    int h = r.Next(minHeight, maxHeight);
                    if(w < minWidth || h < minHeight) { continue; }
                    if(w > maxWidth || h < minHeight) { continue; }
                    int x = r.Next(0, width - w - 1);
                    int y = r.Next(0, height - h - 1);
                    
                    newRoom = new Room(h, w, x, y);
                } while(!free(rooms, newRoom, !allowTouching));

                if(newRoom != null)
                {
                    rooms.Add(newRoom);
                }

                if(consoleOut) { Console.Write(line_clear + "Created room " + rooms.Count + "/" + roomCount + " (" + ((double)rooms.Count / roomCount * 100) + "%)"); }
            } while(rooms.Count < roomCount);

            stopwatch.Stop();
            if(consoleOut)
            {
                Console.Write(line_clear + "Created " + rooms.Count + " rooms in [" + stopwatch.Elapsed + "]");
                Console.WriteLine();
            }
            stopwatch = Stopwatch.StartNew();
            int i = 0;
            foreach(Room room in rooms)
            {
                if(consoleOut) { Console.Write(line_clear + "Put room " + i + "/" + roomCount + " (" + ((double)i / roomCount * 100) + "%)"); }
                putRoomOnMap(map, room);
                i++;
            }
            stopwatch.Stop();
            if(consoleOut)
            {
                Console.Write(line_clear + "Put " + rooms.Count + " rooms in [" + stopwatch.Elapsed + "]");
                Console.WriteLine();
            }

            connectForestRooms(map, rooms, straightness);
        }

        private static void connectForestRooms(Tile[,] map, List<Room> rooms, double straightness)
        {
            //string[] toDelete = Directory.GetFiles(Directory.GetCurrentDirectory(), @"*connectRooms*");
            //foreach(string file in toDelete)
            //{
            //    File.Delete(file);
            //}
            if(rooms == null || rooms.Count < 2)
            {
                return;
            }
            
            List<List<Room>> roomGroups = new List<List<Room>>();
            List<Room> toConnect = new List<Room>(rooms);
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            while(toConnect.Count > 0)
            {
                Room next = toConnect[0];
                Room closest = findClosest(rooms, next);

                List<Room> nextGroup = roomGroups.Find(rl => rl.Contains(next));
                List<Room> closestGroup = roomGroups.Find(rl => rl.Contains(closest));

                if(nextGroup == null && closestGroup == null)
                {
                    List<Room> group = new List<Room>();
                    group.Add(next);
                    group.Add(closest);
                    roomGroups.Add(group);
                    makePath(map, next, closest, straightness);
                }
                else if(nextGroup == closestGroup)
                {
                    //Not null but same group means it's already reachable
                    //Console.WriteLine("Redundant");
                }
                else if(nextGroup == null && closestGroup != null)
                {
                    closestGroup.Add(next);
                    makePath(map, next, closest, straightness);
                }
                else if(nextGroup != null && closestGroup == null)
                {
                    nextGroup.Add(closest);
                    makePath(map, next, closest, straightness);
                }
                else
                {
                    //Two separate groups, join them
                    List<Room> combined = new List<Room>();
                    combined.AddRange(nextGroup);
                    combined.AddRange(closestGroup);
                    makePath(map, next, closest, straightness);
                }
                
                toConnect.RemoveAt(0);
                if(consoleOut) { Console.Write(line_clear + "Connected room " + (rooms.Count - toConnect.Count) + "/" + rooms.Count + " (" + ((double)(rooms.Count - toConnect.Count) / rooms.Count * 100) + "%)"); }
            }

            stopwatch.Stop();
            if(consoleOut)
            {
                Console.Write(line_clear + "Connected " + rooms.Count + " rooms in [" + stopwatch.Elapsed + "]");
                Console.WriteLine();
            }

            stopwatch = Stopwatch.StartNew();
            //Still groups to combine
            int initialRoomGroupCount = roomGroups.Count;
            while(roomGroups.Count > 1)
            {
                (Room, Room) result = getClosestRoomFromEachGroup(roomGroups[0], roomGroups[1]);
                makePath(map, result.Item1, result.Item2, straightness);
                List<List<Room>> newGroups = new List<List<Room>>(roomGroups);
                newGroups.Remove(roomGroups[1]);
                newGroups[0].AddRange(roomGroups[1]);
                roomGroups = newGroups;
                if(consoleOut) { Console.Write(line_clear + "Connected room " + (initialRoomGroupCount - roomGroups.Count) + "/" + initialRoomGroupCount + " (" + ((double)(initialRoomGroupCount - roomGroups.Count) / initialRoomGroupCount * 100) + "%)"); }
            }
            stopwatch.Stop();
            if(consoleOut)
            {
                Console.Write(line_clear + "Connected " + initialRoomGroupCount + " room sets in [" + stopwatch.Elapsed + "]");
                Console.WriteLine();
            }
        }

        private static (Room, Room) getClosestRoomFromEachGroup(List<Room> group1, List<Room> group2)
        {
            double minDist = Double.MaxValue;
            Room room1 = null;
            Room room2 = null;

            foreach(Room group1Room in group1)
            {
                foreach(Room group2Room in group2)
                {
                    double dist = distance(group1Room, group2Room);
                    if(dist < minDist)
                    {
                        room1 = group1Room;
                        room2 = group2Room;
                        minDist = dist;
                    }
                }
            }

            return (room1, room2);
        }
        
        private static void makePath(Tile[,] map, Room room1, Room room2, double straightness)
        {
            //string[] toDelete = Directory.GetFiles(Directory.GetCurrentDirectory(), @"*makePath*");
            //foreach(string file in toDelete)
            //{
            //    File.Delete(file);
            //}

            if(
                (room1.right + 1 == room2.left && ((room1.top >= room2.top && room1.top <= room2.bottom) || (room1.bottom >= room2.top && room1.bottom <= room2.bottom)))   ||  //room1 to left
                (room1.left - 1 == room2.left && ((room1.top >= room2.top && room1.top <= room2.bottom) || (room1.bottom >= room2.top && room1.bottom <= room2.bottom)))    ||  //room1 to right
                (room1.bottom + 1 == room2.top && ((room1.left >= room2.left && room1.left <= room2.right) || (room1.right >= room2.left && room1.right <= room2.right)))   ||  //room1 to top
                (room1.top - 1 == room2.bottom && ((room1.left >= room2.left && room1.left <= room2.right) || (room1.right >= room2.left && room1.right <= room2.right)))       //room1 to bottom
                )
            {
                //No need to do more
                return;
            }


            Random r = new Random();
            
            int horizontal_axis = 0;
            int vertical_axis = 0;

            #region Find direction
            if(room1.right < room2.left) //To the left
            {
                horizontal_axis = 1;
            }
            else if(room1.left > room2.right) //To the right 
            {
                horizontal_axis = -1;
            }

            if(room1.bottom < room2.top) //Above
            {
                vertical_axis = 1;
            }
            else if(room1.top > room2.bottom) //Below
            {
                vertical_axis = -1;
            }
            #endregion

            int start_x = 0;
            int start_y = 0;

            #region Pick a random point along the closest edge of source
            if(horizontal_axis == 0)
            {
                start_x = r.Next(room1.left, room1.right);
            }
            else if(horizontal_axis == -1)
            {
                start_x = room1.left;
            }
            else if(horizontal_axis == 1)
            {
                start_x = room1.right;
            }

            if(vertical_axis == 0)
            {
                start_y = r.Next(room1.top, room1.bottom);
            }
            else if(vertical_axis == -1)
            {
                start_y = room1.top;
            }
            else if(vertical_axis == 1)
            {
                start_y = room1.bottom;
            }
            #endregion
            

            int end_x = 0;
            int end_y = 0;

            #region Pick a random point along closest edge of target
            if(horizontal_axis == 0)
            {
                end_x = r.Next(room2.left, room2.right);
            }
            else if(horizontal_axis == -1)
            {
                end_x = room2.right;
            }
            else if(horizontal_axis == 1)
            {
                end_x = room2.left;
            }

            if(vertical_axis == 0)
            {
                end_y = r.Next(room2.top, room2.bottom);
            }
            else if(vertical_axis == -1)
            {
                end_y = room2.bottom;
            }
            else if(vertical_axis == 1)
            {
                end_y = room2.top;
            }
            #endregion
            
            
            //Generate the path
            int current_x = start_x;
            int current_y = start_y;
            bool? previous_was_horizontal = null;
            while(current_x != end_x || current_y != end_y)
            {
                bool horizontal = current_x != end_x;
                bool vertical = current_y != end_y;

                //If it still needs to go both directions, pick a random one
                if(horizontal && vertical)
                {
                    double horizontal_factor = 0.5;

                    //Only applies after the first because it's a matter of how hard it tries to keep it straight
                    if(previous_was_horizontal != null)
                    {
                        //Should only ever be the actual value because I've already checked if it was null, just written like this to make the compiler happy
                        bool was_horizontal = previous_was_horizontal.HasValue ? previous_was_horizontal.Value : false;
                        
                        if(was_horizontal)
                        {
                            horizontal_factor *= (straightness * 2); //If given 1, horizontal_factor becomes 1, forcing it horizontal
                        }
                        else
                        {
                            horizontal_factor /= (straightness * 2); //If given 0, horizontal_factor becomes 0, forcing it vertical
                        }
                    }
                    
                    if(r.NextDouble() > horizontal_factor) //Vertical
                    {
                        horizontal = false;
                    }
                    else //Horizontal
                    {
                        vertical = false;
                    }
                }

                if(vertical)
                {
                    current_y += Math.Sign(end_y - current_y);
                }
                else if(horizontal)
                {
                    current_x += Math.Sign(end_x - current_x);
                }

                previous_was_horizontal = horizontal;

                map[current_x, current_y] = new Floor();
            }
        }

        private static Room findClosest(List<Room> rooms, Room find)
        {
            double minDistance = Int32.MaxValue;
            Room closest = null;

            Point myCenter = find.center;

            //Center points is good enough of an estimate... for now at least

            foreach(Room room in rooms)
            {
                if(room == find) { continue; }

                Point roomCenter = room.center;
                double dist = distance(myCenter, roomCenter);
                if(dist < minDistance)
                {
                    closest = room;
                    minDistance = dist;
                }
            }

            return closest;
        }
        
        static double distance(Room r1, Room r2)
        {
            return distance(r1.center, r2.center);
        }

        static double distance(Point p1, Point p2)
        {
            return Math.Sqrt((Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2)));
        }
        
        static int orientation(Point p, Point q, Point r)
        {
            int val =   (q.y - p.y) * (r.x - q.x) -
                        (q.x - p.x) * (r.y - q.y);

            if(val == 0) return 0; // colinear 

            return (val > 0) ? 1 : 2; // clock or counterclock wise 
        }

        private static bool onSegment(Point p, Point q, Point r)
        {
            return q.x <= Math.Max(p.x, r.x) && q.x >= Math.Min(p.x, r.x) &&
                    q.y <= Math.Max(p.y, r.y) && q.y >= Math.Min(p.y, r.y);
        }
        
        private static bool free(List<Room> preexisting, Room toAdd, bool allowTouching)
        {
            if((preexisting?.Count ?? 0) == 0 || toAdd == null) { return true; }

            foreach(Room current in preexisting)
            {
                if(roomsCollide(toAdd, current, allowTouching))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        public static IEnumerable<T> shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            T[] elements = source.ToArray();
            for(int i = elements.Length - 1; i >= 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                // ... except we don't really need to swap it fully, as we can
                // return it immediately, and afterwards it's irrelevant.
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }

        private static bool roomsCollide((Room, Room) rooms, bool allowTouching)
        {
            return roomsCollide(rooms.Item1, rooms.Item2, allowTouching);
        }

        private static bool roomsCollide(Room room1, Room room2, bool allowTouching)
        {
            return lineSegmentListCollides(getEdgeLines(room1, allowTouching), getEdgeLines(room2, allowTouching)) || encompases(room1, room2);
        }

        static bool lineSegmentListCollides(List<(Point, Point)> list1, List<(Point, Point)> list2)
        {
            if((list1?.Count ?? 0) == 0 || (list2?.Count ?? 0) == 0) { return false; }
            foreach((Point, Point) list1Edge in list1)
            {
                foreach((Point, Point) list2Edge in list2)
                {
                    if(doIntersect(list1Edge.Item1, list1Edge.Item2, list2Edge.Item1, list2Edge.Item2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool encompases(Room room1, Room room2)
        {
            return (room1.left <= room2.left && room1.right >= room2.right && room1.top <= room2.top && room1.bottom >= room2.bottom) ||    //room1 encompasses
                    (room2.left <= room1.left && room2.right >= room1.right && room2.top <= room1.top && room2.bottom >= room1.bottom);     //room2 encompasses
        }

        static bool doIntersect(Point p1, Point q1, Point p2, Point q2)
        {
            // Find the four orientations needed for general and 
            // special cases 
            int o1 = orientation(p1, q1, p2);
            int o2 = orientation(p1, q1, q2);
            int o3 = orientation(p2, q2, p1);
            int o4 = orientation(p2, q2, q1);

            // General case 
            if(o1 != o2 && o3 != o4)
            {
                return true;
            }

            // Special Cases 
            // p1, q1 and p2 are colinear and p2 lies on segment p1q1 
            if(o1 == 0 && onSegment(p1, p2, q1)) { return true; }

            // p1, q1 and q2 are colinear and q2 lies on segment p1q1 
            if(o2 == 0 && onSegment(p1, q2, q1)) { return true; }

            // p2, q2 and p1 are colinear and p1 lies on segment p2q2 
            if(o3 == 0 && onSegment(p2, p1, q2)) { return true; }

            // p2, q2 and q1 are colinear and q1 lies on segment p2q2 
            if(o4 == 0 && onSegment(p2, q1, q2)) { return true; }

            return false; // Doesn't fall in any of the above cases 
        }

        static List<(Point, Point)> getEdgeLines(Room room, bool withSpacing)
        {
            List<(Point, Point)> ret = new List<(Point, Point)>();

            if(withSpacing)
            {
                ret.Add((room.spaced_top_left, room.spaced_top_right));
                ret.Add((room.spaced_top_right, room.spaced_bottom_right));
                ret.Add((room.spaced_bottom_left, room.spaced_bottom_right));
                ret.Add((room.spaced_top_left, room.spaced_bottom_left));
            }
            else
            {
                ret.Add((room.top_left, room.top_right));
                ret.Add((room.top_right, room.bottom_right));
                ret.Add((room.bottom_left, room.bottom_right));
                ret.Add((room.top_left, room.bottom_left));
            }

            return ret;
        }

        private static void putRoomsOnMap(Tile[,] map, List<Room> rooms)
        {
            foreach(Room room in rooms)
            {
                putRoomOnMap(map, room);
            }
        }

        private static void putRoomOnMap(Tile[,] map, Room room)
        {
            for(int x = room.left; x <= room.right; x++)
            {
                for(int y = room.top; y <= room.bottom; y++)
                {
                    if(map[x, y] is Floor)
                    {
                        map[x, y] = new Floor2();
                    }
                    else
                    {
                        map[x, y] = new Floor();
                    }
                }
            }
        }
        
        private static void generateImg(Tile[,] map, string name, int scale = 1)
        {
            Console.WriteLine("generateImg() is disabled");
            //int width = map.GetLength(0);
            //int height = map.GetLength(1);
            
            //Bitmap img = new Bitmap(width, height);
            
            //for(int y = 0; y < height; y++)
            //{
            //    for(int x = 0; x < width; x++)
            //    {
            //        img.SetPixel(x, y, map[x, y].color);
            //    }
            //}

            //if(scale > 1)
            //{
            //    Bitmap scaled = new Bitmap(width * scale, height * scale);
            //    using(Graphics g = Graphics.FromImage(scaled))
            //    {
            //        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //        g.DrawImage(img, 0, 0, width * scale, height * scale);
            //    }
            //    img = scaled;
            //}

            //img.Save(name);
        }

        private static Tile[,] createEmptyMapOfSize(int width, int height)
        {
            return create2DArrayOfSize<Tile>(width, height, new Wall());
        }

        private static T[,] create2DArrayOfSize<T>(int width, int height, T defaultValue)
        {
            T[,] map = new T[width, height];
            System.Threading.Tasks.Parallel.For(0, width, i =>
            {
                for(int j = 0; j < height; j++)
                {
                    map[i, j] = defaultValue;
                }
            });
            return map;
        }
    }

    public abstract class Tile
    {
        //public readonly Color color;

        //public Tile(Color color) { this.color = color; }
    }

    public class Wall : Tile
    {
        //public Wall() : base(Color.Black) { }
    }

    public class Floor : Tile
    {
        //public Floor() : base(Color.White) { }
    }

    public class Floor2 : Tile
    {
        //public Floor2() : base(Color.Gray) { }
    }

    public class DebugRed : Tile
    {
        //public DebugRed() : base(Color.Red) { }
    }

    public class DebugGreen : Tile
    {
        //public DebugGreen() : base(Color.Green) { }
    }

    public class Room
    {
        public int height;
        public int width;
        public int x;
        public int y;

        public int left { get { return x; } }
        public int right { get { return left + width - 1; } } //Without the - 1 it double counts the first square
        public int top { get { return y; } }
        public int bottom { get { return top + height - 1; } } //Without the - 1 it double counts the first square

        public Point top_left { get { return new Point(left, top); } }
        public Point top_right { get { return new Point(left, bottom); } }
        public Point bottom_left { get { return new Point(right, top); } }
        public Point bottom_right { get { return new Point(right, bottom); } }

        public Point spaced_top_left { get { return new Point(left - 1, top - 1); } }
        public Point spaced_top_right { get { return new Point(left - 1, bottom + 1); } }
        public Point spaced_bottom_left { get { return new Point(right + 1, top - 1); } }
        public Point spaced_bottom_right { get { return new Point(right + 1, bottom + 1); } }

        public Point center { get { return new Point( (left + right)/2, (top + bottom)/2 ); } }

        //For debug purposes (easy copy/paste into code)
        private string props { get { return "x = " + x + ";\ny = " + y + ";\nw = " + width + ";\nh = " + height + ";\n";  } }

        public Room(int height, int width, int x, int y)
        {
            this.height = height;
            this.width = width;
            this.x = x;
            this.y = y;
        }
    }

    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
