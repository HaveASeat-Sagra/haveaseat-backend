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
        public const string BottomLeft = "none none solid solid";
        public const string BottomRight = "none solid solid none";
    }
    public static WebApplication SeedMap(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            try
            {
                context.Database.EnsureCreated();
                Room? rooms = context.Rooms.FirstOrDefault();

                if (rooms == null)
                {
                    context.Rooms.AddRange(
                        new Room { Id = 1, Name = "2.7" },
                        new Room { Id = 2, Name = "2.8" },
                        new Room {Id = 3, Name = "2.9"},
                        new Room {Id = 4, Name = "2.10"},
                        new Room {Id = 5, Name = "2.11"}
                    );
                }

                context.SaveChanges();

                // room 2.7
                if (context.Rooms.FirstOrDefault(r => r.Id == 1).Cells == null)
                {

                    for (int y = 1; y <= 4; y++)
                    {
                        for (int x = 1; x <= 2; x++)
                        {
                            string border = Border.None;
                            if (y == 1 && x == 1)
                            {
                                border = Border.TopLeft;
                            }
                            
                            else if (y == 4 && x == 1)
                            {
                                border = Border.BottomLeft;
                            }

                            else if (y == 1 && x == 2)
                            {
                                border = Border.TopRight;
                            }
                            
                            else if (x == 1)
                            {
                                border = Border.Left;
                            }

                            else if (y == 1)
                            {
                                border = Border.Top;
                            }

                            else if (x == 2)
                            {
                                border = Border.Right;
                            }
                            


                            map.Add(new Cell
                            {
                                PositionX = x,
                                PositionY = y,
                                Border = border,
                                RoomId = 1,
                            });
                        }
                    }
                }

                //room 2.8
                if (context.Rooms.FirstOrDefault(r => r.Id == 2).Cells == null)
                {

                    for (int y = 1; y <= 4; y++)
                    {
                        for (int x = 5; x <= 6; x++)
                        {
                            string border = Border.None;
                            if (y == 1 && x == 5)
                            {
                                border = Border.TopLeft;
                            }
                            else if (y == 4 && x == 6)
                            {
                                border = Border.BottomRight;
                            }

                            else if (y == 1 && x == 6)
                            {
                                border = Border.TopRight;
                            }
                            else if (x == 5)
                            {
                                border = Border.Left;
                            }

                            else if (y == 1)
                            {
                                border = Border.Top;
                            }

                            else if (x == 6)
                            {
                                border = Border.Right;
                            }

                            map.Add(new Cell
                            {
                                PositionX = x,
                                PositionY = y,
                                Border = border,
                                RoomId = 2,
                            });
                        }
                    }
                }
                
                // room 2.9
                if (context.Rooms.FirstOrDefault(r => r.Id == 3).Cells == null)
                {

                    //room 2.9
                    for (int y = 1; y <= 6; y++)
                    {
                        for (int x = 7; x <= 8; x++)
                        {
                            string border = Border.None;
                            if (y == 1 && x == 7)
                            {
                                border = Border.TopLeft;
                            }
                            else if (y == 6 && x == 8)
                            {
                                border = Border.BottomRight;
                            }

                            else if (y == 1 && x == 8)
                            {
                                border = Border.TopRight;
                            }
                            
                            else if (x == 7)
                            {
                                border = Border.Left;
                            }

                            else if (y == 1)
                            {
                                border = Border.Top;
                            }

                            else if (x == 8)
                            {
                                border = Border.Right;
                            }
                            

                            map.Add(new Cell
                            {
                                PositionX = x,
                                PositionY = y,
                                Border = border,
                                RoomId = 3,
                            });
                        }
                    }
                }
                
                // room 2.10
                if (context.Rooms.FirstOrDefault(r => r.Id == 4).Cells == null)
                {

                    for (int y = 1; y <= 3; y++)
                    {
                        for (int x = 9; x <= 12; x++)
                        {
                            string border = Border.None;
                            if (y == 1 && x == 9)
                            {
                                border = Border.TopLeft;
                            }

                            else if (y == 1 && x == 12)
                            {
                                border = Border.TopRight;
                            }
                            
                            else if (y == 3 && x == 12)
                            {
                                border = Border.BottomRight;
                            }
                            
                            else if (x == 9)
                            {
                                border = Border.Left;
                            }

                            else if (y == 1)
                            {
                                border = Border.Top;
                            }
                            
                            else if (y == 3 && x == 11)
                            {
                                border = Border.Bottom;
                            }

                            map.Add(new Cell
                            {
                                PositionX = x,
                                PositionY = y,
                                Border = border,
                                RoomId = 4,
                            });
                        }
                    }
                    
                    for (int y = 4; y <= 6; y++)
                    {
                        for (int x = 9; x <= 10; x++)
                        {
                            string border = Border.None;
                            
                            if (y == 6 && x == 9)
                            {
                                border = Border.BottomLeft;
                            }
                            
                            else if (y == 6 && x == 10)
                            {
                                border = Border.Bottom;
                            }
                            
                            else if (x == 9)
                            {
                                border = Border.Left;
                            }
                            
                            else if (x == 10)
                            {
                                border = Border.Right;
                            }
                            

                            map.Add(new Cell
                            {
                                PositionX = x,
                                PositionY = y,
                                Border = border,
                                RoomId = 4,
                            });
                        }
                    }
                }
                
                // room 2.11
                if (context.Rooms.FirstOrDefault(r => r.Id == 5).Cells == null)
                {

                    for (int y = 1; y <= 3; y++)
                    {
                        for (int x = 13; x <= 15; x++)
                        {
                            string border = Border.None;
                            if (y == 1 && x == 13)
                            {
                                border = Border.TopLeft;
                            }

                            else if (y == 1 && x == 15)
                            {
                                border = Border.TopRight;
                            }
                            
                            else if (y == 3 && x == 13)
                            {
                                border = Border.BottomLeft;
                            }
                            
                            else if (x == 15)
                            {
                                border = Border.Right;
                            }

                            else if (y == 1)
                            {
                                border = Border.Top;
                            }

                            map.Add(new Cell
                            {
                                PositionX = x,
                                PositionY = y,
                                Border = border,
                                RoomId = 4,
                            });
                        }
                    }
                    
                    for (int y = 4; y <= 6; y++)
                    {
                        for (int x = 14; x <= 15; x++)
                        {
                            string border = Border.None;
                            
                            if (y == 6 && x == 15)
                            {
                                border = Border.BottomRight;
                            }
                            
                            else if (x == 14)
                            {
                                border = Border.Left;
                            }
                            
                            else if (x == 15)
                            {
                                border = Border.Right;
                            }
                            

                            map.Add(new Cell
                            {
                                PositionX = x,
                                PositionY = y,
                                Border = border,
                                RoomId = 4,
                            });
                        }
                    }
                    context.Cells.AddRange(map);
                    context.SaveChanges();
                }
                
                // room 2.12
                if (context.Rooms.FirstOrDefault(r => r.Id == 6).Cells == null)
                {

                    for (int y = 1; y <= 4; y++)
                    {
                        for (int x = 16; x <= 19; x++)
                        {
                            string border = Border.None;
                            if (y == 1 && x == 16)
                            {
                                border = Border.TopLeft;
                            }

                            else if (y == 1 && x == 19)
                            {
                                border = Border.TopRight;
                            }
                            
                            else if (y == 4 && x == 19)
                            {
                                border = Border.BottomRight;
                            }
                            
                            else if (x == 19)
                            {
                                border = Border.Right;
                            }
                            
                            else if (x == 16)
                            {
                                border = Border.Left;
                            }

                            else if (y == 1)
                            {
                                border = Border.Top;
                            }
                            
                            else if (x == 18 && y == 4)
                            {
                                border = Border.Bottom;
                            }

                            map.Add(new Cell
                            {
                                PositionX = x,
                                PositionY = y,
                                Border = border,
                                RoomId = 4,
                            });
                        }
                    }
                    
                    for (int y = 5; y <= 6; y++)
                    {
                        for (int x = 16; x <= 17; x++)
                        {
                            string border = Border.None;
                            
                            if (y == 6 && x == 16)
                            {
                                border = Border.BottomLeft;
                            }
                            
                            else if (x == 17 && y == 6)
                            {
                                border = Border.Right;
                            }
                            
                            else if (x == 16)
                            {
                                border = Border.Left;
                            }
                            

                            map.Add(new Cell
                            {
                                PositionX = x,
                                PositionY = y,
                                Border = border,
                                RoomId = 6,
                            });
                        }
                    }
                    context.Cells.AddRange(map);
                    context.SaveChanges();
                }
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