using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour // julkinen ryhmä eli voi muuttaa myös unityssä       
{
    public class CellData // tehdään sisäkkäinen luokka, koska sitä käytetään vain BoardManagerissa mutta sen voi saada myös käyttöön BoardManager.CellData
    {
        public bool Passable; // tehdään luokka passable, joka kertoo onko ruutu läpäistävä vai ei
    }
    

    private CellData[,] m_BoardData; // tehdään 2D taulukko, joka sisältää CellData-olioita, jotka kertovat onko ruutu läpäistävä vai ei
    private Tilemap m_Tilemap; // tehdään Tilemap-olio, joka sisältää ruudut, jotka piirretään ruudulle

    private Grid m_Grid;

    public int Width; // julkinen leveys, joka voidaan asettaa unityssä
    public int Height; // julkinen korkeus, joka voidaan asettaa unityssä
    public Tile[] GroundTiles; // julkinen taulukko, joka sisältää maapohjan ruudut, jotka voidaan asettaa unityssä
    public Tile[] WallTiles; // julkinen taulukko, joka sisältää seinäruudut, jotka voidaan asettaa unityssä

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Init()
    {

        m_Tilemap = GetComponentInChildren<Tilemap>(); // haetaan Tilemap-olio, joka on lapsena BoardManagerissa
        m_Grid = GetComponentInChildren<Grid>();

        m_BoardData = new CellData[Width, Height]; // alustetaan 2D taulukko, joka sisältää CellData-olioita, jotka kertovat onko ruutu läpäistävä vai ei

        for (int y = 0; y < Height; ++y) // käydään läpi kaikki rivit
        {
            for (int x = 0; x < Width; ++x) // käydään läpi kaikki sarakkeet
            {
                m_BoardData[x, y] = new CellData();
                Tile tile; // tehdään Tile-olio, joka sisältää ruudun, joka piirretään ruudulle
                

                if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1) // jos ollaan reunalla, niin laitetaan seinäruutu
                {
                    tile = WallTiles[Random.Range(0, WallTiles.Length)];
                    m_BoardData[x, y].Passable = false;
                }
                else
                {
                    tile = GroundTiles[Random.Range(0, GroundTiles.Length)]; // jos ei olla reunalla, niin laitetaan maapohjan ruutu
                    m_BoardData[x, y].Passable = true;
                }
                m_Tilemap.SetTile(new Vector3Int(x, y, 0), tile); // asetetaan ruutu ruudulle
            }
        }

        
    }
    
    public Vector3 CellToWorld(Vector2Int cellIndex)
    {
        return m_Grid.GetCellCenterWorld((Vector3Int)cellIndex);
    }
    public CellData GetCellData(Vector2Int cellIndex)
    {
        if (cellIndex.x < 0 || cellIndex.x >= Width
            || cellIndex.y < 0 || cellIndex.y >= Height)
        {
            return null;
        }

        return m_BoardData[cellIndex.x, cellIndex.y];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
