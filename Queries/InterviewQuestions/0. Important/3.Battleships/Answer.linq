<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
	string shipCoordinatesStrings = "1B 2C,2D 4D";
	string hitCoordinateStrings = "2B 2D 3D 4D 4A";
	int gridLength = 4;

	var results = new Solution().solution(gridLength, shipCoordinatesStrings, hitCoordinateStrings );
	MyExtensions.AreEqual("1,1", results);

	shipCoordinatesStrings = "1A 1B,2C 2C";
	hitCoordinateStrings = "1B";
	gridLength = 3;
	results = new Solution().solution(gridLength, shipCoordinatesStrings, hitCoordinateStrings);
	MyExtensions.AreEqual("0,1", results);


	MyExtensions.AreEqual("1,0", new Solution().solution(3, "1A 1A", "1A"));
	MyExtensions.AreEqual("1,0", new Solution().solution(26, "26Z 26Z", "26Z"));
	MyExtensions.AreEqual("0,1", new Solution().solution(26, "25Y 26Z", "26Z"));
	MyExtensions.AreEqual("1,1", new Solution().solution(26, "25Y 26Z,1A 1A", "26Z 1A"));
}4,


class Solution
{
	public string solution(int n, string s, string t)
	{
		Ship[,] board = new Ship[n, n];
		IEnumerable<Ship> ships = s.ToShips();
		IEnumerable<Coordinate> hitCoordinats = t.ToHitCoordinates();
		
		PlaceShipsOnBoard(board, ships);
		var results =  FireShots(board, hitCoordinats);
		
		return $"{results[1]},{results[0]}";
	}
	
	private int[] FireShots(Ship[,] board, IEnumerable<Coordinate> coordinates)
	{
		int hitShips = 0;
		int sunkShips = 0;
	
		foreach (var coorodinate in coordinates)
		{
			var ship = board[coorodinate.RowId, coorodinate.ColumnId];
			
			if (ship != null)
			{
				// Remove the ship from this co-ordinate so it cant get
				// hit on same cell twice
				board[coorodinate.RowId, coorodinate.ColumnId] = null;
				
				// On the first hit we add the ship to the 
				// hit ships count
				if (ship.HitCellCount++ == 0 )
					hitShips++;
				
				if (ship.HitCellCount == ship.OriginalCellCount)
				{
					// This ship is sunk
					sunkShips++;
					
					// Remove it from hit count to prevent double counting
					hitShips--;
				}
			}
		}

		return new int[] { hitShips, sunkShips};
	}

	private void PlaceShipsOnBoard(Ship[,] board, IEnumerable<Ship> ships)
	{
		foreach (var ship in ships)
		{
			for (int rowIdx = ship.TopLeft.RowId; rowIdx <= ship.BottomRight.RowId; rowIdx++)
			{
				for (int colIdx = ship.TopLeft.ColumnId; colIdx <= ship.BottomRight.ColumnId; colIdx++)
				{
					board[rowIdx, colIdx] = ship;
				}
			}
		}
	}
}

/// <summary>
/// Utilites to help with string parsing
/// </summary>
public static class StringUtilities 
{
	public static Ship ToShip(this string coordinatesString)
	{
		var cordinateStrings = coordinatesString.Split(' ');
		var topLeftString = cordinateStrings[0];
		var bottomRightString = cordinateStrings[1];

		var topLeft = topLeftString.ToCoordinate();
		var bottomRight = bottomRightString.ToCoordinate();

		return new Ship(topLeft, bottomRight);
	}

	public static Coordinate ToCoordinate(this string coordinateString)
	{
		// Assume last character is uppercase letter. Strip it off
		// and convert to integer base zero
		var columnIndex = coordinateString[coordinateString.Length - 1] - 'A';

		// Convert integral part to rows/y-coord in base zero
		var rowIndex = int.Parse(coordinateString.Substring(0, coordinateString.Length - 1)) - 1;

		var coordinate = new Coordinate
		{
			RowId = rowIndex,
			ColumnId = columnIndex
		};

		return coordinate;
	}

	public static IEnumerable<Coordinate> ToHitCoordinates(this string coordinatesString)
	{
		var hitCoordinates = coordinatesString
			.Split(" ")
			.Select(coordinateString => coordinateString.ToCoordinate());

		return hitCoordinates;
	}

	public static IEnumerable<Ship> ToShips(this string shipCoordinateStrings)
	{
		var ships = shipCoordinateStrings
			.Split(",")
			.Select(coordinatesString => coordinatesString.ToShip());

		return ships;
	}
}

/// <summary>
/// Each ship knows the subset of the board it occupies before
/// any shots are fired. It also keeps track of any hits 
/// enabling us to calculate if it either damaged or sunk
/// </summary>
public class Ship
{
	public Ship(Coordinate topLeft, Coordinate bottomRight)
	{
		TopLeft = topLeft;
		BottomRight = bottomRight;

		HitCellCount = 0;
		OriginalCellCount = CalculateArea(topLeft, bottomRight);
	}

	public Coordinate TopLeft { get; }

	public Coordinate BottomRight { get; }

	public int OriginalCellCount { get; set; }

	public int HitCellCount { get; set; }

	public override string ToString() => $"O:{OriginalCellCount}, H:{HitCellCount}";

	private int CalculateArea(Coordinate topLeft, Coordinate bottomRight)
	{
		var length = bottomRight.ColumnId - topLeft.ColumnId + 1;
		var height = bottomRight.RowId - topLeft.RowId + 1;
		return length * height;
	}
}


/// <summary>
/// Helper class to tie together row and column Ids
/// </summary>
public class Coordinate
{
	public int RowId { get; set; }
	public int ColumnId { get; set; }
}

// Just in case I need them for more complex expressions
Regex charRegex = new Regex("[a-zA-Z]+", RegexOptions.Compiled);
Regex digitsRegex = new Regex("[0-9]+", RegexOptions.Compiled);
