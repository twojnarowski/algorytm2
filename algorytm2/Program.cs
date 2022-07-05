List<(int start, int end)> classTimes = new();
List<(int start, int end)> classRooms = new();
for (int i = 0; i < args.Length; i += 2)
{
    classTimes.Add((Convert.ToInt32(args[i]), Convert.ToInt32(args[i + 1])));
}
while (classTimes.Count > 0)
{
    var earliest = classTimes.OrderBy(s => s.start).First();
    var index = classRooms.FindIndex(s => s.end <= earliest.start);
    if (index >= 0)
    {
        var temp = classRooms[index];
        temp.end = earliest.end;
        classRooms[index] = temp;
    }
    else
    {
        classRooms.Add(earliest);
    }
    classTimes.Remove(earliest);
}
Console.WriteLine(classRooms.Count);