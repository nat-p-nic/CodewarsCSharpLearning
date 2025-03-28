namespace Codewars.Library
{
    public class BattleshipField
    {
        const int BIGGEST_SHIP_SIZE = 4;
        const int GRID_SQUARE_SIZE = 10;

        private static ShipType GetShipType(int shipStart, int shipEnd)
                        => (ShipType)((shipEnd - shipStart) + 1);

        public static bool ValidateBattlefield(int[,] field)
        {
            List<Ship> shipList = [];

            for (int y = 0; y < GRID_SQUARE_SIZE; y++)
            {
                for (int x = 0; x < GRID_SQUARE_SIZE; x++)
                {
                    if (field[x, y] == 1)
                    {
                        // Return invalid if any ship is touching this ship's diagonals
                        if (IsShipAtPosition(field, x - 1, y - 1) == 1 || IsShipAtPosition(field, x + 1, y - 1) == 1
                            || IsShipAtPosition(field, x + 1, y + 1) == 1 || IsShipAtPosition(field, x - 1, y + 1) == 1)
                            return false;

                        // Find ship, add to list and remove from field
                        var ship = FindShip(field, x, y);
                        if (ship.Type == ShipType.Invalid)
                            return false;

                        shipList.Add(ship);
                        field = RemoveShipFromField(field, ship);
                    }
                }
            }

            // Return invalid if ship counts are incorrect
            if (shipList.Count(c => c.Type == ShipType.Battleship) != 1
                    || shipList.Count(c => c.Type == ShipType.Cruiser) != 2
                    || shipList.Count(c => c.Type == ShipType.Destroyer) != 3
                    || shipList.Count(c => c.Type == ShipType.Submarine) != 4)
                return false;

            return true;
        }

        private static int IsShipAtPosition(int[,] field, int x, int y)
        {
            if (x < 0 || y < 0 || x >= GRID_SQUARE_SIZE || y >= GRID_SQUARE_SIZE)
                return 0;

            int shipAtPosition = field[x, y];

            return shipAtPosition;
        }

        private static Ship FindShip(int[,] field, int x, int y)
        {
            bool horizontalNegativeHit = (IsShipAtPosition(field, x - 1, y) == 1);
            bool horizontalPositiveHit = (IsShipAtPosition(field, x + 1, y) == 1);
            bool verticalNegativeHit = (IsShipAtPosition(field, x, y - 1) == 1);
            bool verticalPositiveHit = (IsShipAtPosition(field, x, y + 1) == 1);

            if ((horizontalNegativeHit || horizontalPositiveHit) && (verticalNegativeHit || verticalPositiveHit))
            {
                // Invalid
                return new Ship
                {
                    Type = ShipType.Invalid
                };
            }

            if (!verticalNegativeHit && !verticalPositiveHit && !horizontalNegativeHit && !horizontalPositiveHit)
            {
                // Submarine
                return new Ship
                {
                    Position = new Position()
                    {
                        Start = new Axes() { X = x, Y = y },
                        End = new Axes() { X = x, Y = y }
                    },
                    Orientation = Orientation.None,
                    Type = ShipType.Submarine
                };
            }

            var ship = new Ship();
            if (horizontalNegativeHit || horizontalPositiveHit)
                ship = IdentifyHorizontalShip(field, x, y);
            if (verticalNegativeHit || verticalPositiveHit)
                ship = IdentifyVerticalShip(field, x, y);

            return ship;
        }

        private static int[,] RemoveShipFromField(int[,] field, Ship ship)
        {
            var position = ship.Position;
            if (ship.Orientation == Orientation.Horizontal)
            {
                for (int x = position.Start.X; x <= position.End.X; x++)
                    field[x, position.Start.Y] = 0;
            }
            else
            {
                for (int y = position.Start.Y; y <= position.End.Y; y++)
                    field[position.Start.X, y] = 0;
            }

            return field;
        }

        private static Ship IdentifyHorizontalShip(int[,] field, int x, int y)
        {
            int shipStart = -1;
            int shipEnd = -1;
            for (int i = (x - 1); i <= x + BIGGEST_SHIP_SIZE; i++)
            {
                if (IsShipAtPosition(field, i, y) == 1 && shipStart < 0)
                    shipStart = i;

                if (IsShipAtPosition(field, i, y) == 0 && shipStart > -1 && shipEnd == -1)
                    shipEnd = i - 1;
            }

            return new Ship()
            {
                Position = new Position()
                {
                    Start = new Axes { X = shipStart, Y = y },
                    End = new Axes { X = shipEnd, Y = y }
                },
                Orientation = Orientation.Horizontal,
                Type = GetShipType(shipStart, shipEnd)
            };
        }

        private static Ship IdentifyVerticalShip(int[,] field, int x, int y)
        {
            int shipStart = -1;
            int shipEnd = -1;
            for (int i = (y - 1); i <= y + BIGGEST_SHIP_SIZE; i++)
            {
                if (IsShipAtPosition(field, x, i) == 1 && shipStart < 0)
                    shipStart = i;

                if (IsShipAtPosition(field, x, i) == 0 && shipStart > -1 && shipEnd == -1)
                    shipEnd = i - 1;
            }

            return new Ship()
            {
                Position = new Position()
                {
                    Start = new Axes { X = x, Y = shipStart },
                    End = new Axes { X = x, Y = shipEnd }
                },
                Orientation = Orientation.Vertical,
                Type = GetShipType(shipStart, shipEnd)
            };
        }

        internal class Ship()
        {
            internal Orientation Orientation;
            internal Position Position = new();
            internal ShipType Type;
        }

        internal enum ShipType
        {
            Battleship = 4,
            Cruiser = 3,
            Destroyer = 2,
            Submarine = 1,
            Invalid = 0
        }

        internal enum Orientation
        {
            Horizontal,
            Vertical,
            None
        }

        internal class Position
        {
            internal Axes Start = new();
            internal Axes End = new();
        }

        internal class Axes
        {
            internal int X = 0;
            internal int Y = 0;
        }
    }
}