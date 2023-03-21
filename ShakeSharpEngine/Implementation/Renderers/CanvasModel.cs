namespace ShakeSharpEngine.Implementation.Renderers;

/// <summary>
/// (Eng) This class represents a console model that contains information about the current console's width and height.
/// (Esp) Esta clase representa un modelo de consola que contiene información sobre el ancho y el alto de la consola actual.
/// (Ger) Diese Klasse stellt ein Konsolenmodell dar, das Informationen über die aktuelle Breite und Höhe der Konsole enthält.
/// (Ita) Questa classe rappresenta un modello di console che contiene informazioni sull'ampiezza e l'altezza della console corrente.
/// (Por) Esta classe representa um modelo de console que contém informações sobre a largura e a altura do console atual.
/// (Fin) Tämä luokka edustaa konsolimallia, joka sisältää tietoja nykyisen konsolin leveydestä ja korkeudesta.
/// </summary>
public class CanvasModel
{
    public CanvasModel()
    {
        
        
    }
    
    public CanvasModel(int width, int height)
    {
        Width = width;
        Height = height;
    }
    
    // TODO: change all of this
    /// <summary>
    /// Gets or sets the width of the canvas coordinates.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the canvas coordinates.
    /// </summary>
    public int Height { get; set; }
}