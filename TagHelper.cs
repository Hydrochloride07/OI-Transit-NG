public class TagHelper
{
    public void Update(List<string> tags, string date)
    {
        if (tags.Count == 0) return;
        tags = tags.Distinct().ToList();
        using var db = new TransContext();

        foreach (var tag in tags)
        {
            var li = db.Tags.Where(u => u.Name == tag).ToList();
            if (li.Count() != 0)
            {
                var t = li[0];
                t.LastVisit = date;
                db.Update(t);
            } else
            {
                Tag t = new Tag { Name = tag , LastVisit = date, Comments = "" };
                db.Add(t);
            }
        }
        db.SaveChanges();
    }
}