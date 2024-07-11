using haveaseat.DbContexts;
using haveaseat.DTOs;

namespace haveaseat_api.Seeders;

public static class MapSeeder
{

    private static List<Cell> map = new List<Cell>();

    private static class Border
    {
        public const string Left = "none none none solid";
        public const string TopLeft = "solid none none solid";
        public const string Top = "solid none none none";
        public const string None = "none";
        public const string Right = "none solid none none";
        public const string Bottom = "none none solid none";
        public const string TopRight = "solid solid none none";
    }
    public static WebApplication SeedMap(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            try
            {
                context.Database.EnsureCreated();
                Cell? cells = context.Cells.FirstOrDefault();
                Room? rooms = context.Rooms.FirstOrDefault();

                if (rooms == null)
                {
                    context.Rooms.AddRange(
                        new Room { Id = 1, Name = "2.7" });
                }

                context.SaveChanges();
                
                if (cells == null)
                {
                    // room 2.7
                    
                    for (int i = 1; i <= 4; i++)
                    {
                        for (int j = 1; j <= 2; j++)
                        {
                            string border = Border.None;
                            if(i == 1 && j == 1)
                            {
                                border = Border.TopLeft;
                            } 
                            else if (j == 1)
                            {
                                border = Border.Left;
                            }
                            
                            else if (i == 1)
                            {
                                border = Border.Top;
                            }
                            
                            else if (j == 2)
                            {
                                border = Border.Right;
                            }
                            
                            else if (i == 4 && j == 1)
                            {
                                border = Border.Bottom;
                            }
                            
                            else if (i == 1 && j == 2)
                            {
                                border = Border.TopRight;
                            }
                            
                            map.Add( new Cell
                            {
                                PositionX = j,
                                PositionY = i,
                                Border = border,
                                RoomId = 1,
                            });
                        }
                    }
                    
                    //room 
                    context.Cells.AddRange(map);
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return app;
    }
}