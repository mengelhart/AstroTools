module Equipment

open System

[<Measure>] type mm
[<Measure>] type degree
[<Measure>] type kg

type Manufacturer = Manufacturer of string
type Design = Design of string

type Eyepiece = {
    Id: Guid
    Manufacturer: Manufacturer    
    FocalLength: float<mm>
    EyeRelief: float<mm>
    BarrelDiameter: float<mm>
    ApparentFieldOfView: int<degree>
    Weight: float<kg>
}

type Telescope =  {
    Id: Guid
    Manufacturer: Manufacturer
    Design: Design
    FocalLength: float<mm>
    Aperture: float<mm>
    Weight: float<kg>
}

let tv55: Eyepiece = {
    Id = Guid.NewGuid()
    Manufacturer = Manufacturer "TeleVue"
    Weight = 0.5131<kg>    
    FocalLength = 55.0<mm>
    EyeRelief = 38.0<mm>
    BarrelDiameter = 50.8<mm>;
    ApparentFieldOfView = 50<degree>
}

let c8: Telescope = {
    Id = Guid.NewGuid()
    Manufacturer = Manufacturer "TeleVue"
    Design = Design "Reflector"
    FocalLength = 2032.0<mm>
    Aperture = 203.2<mm>
    Weight = 7.5<kg>
}

let magnification (telescope: Telescope) (eyepiece: Eyepiece) : float =
    telescope.FocalLength /  eyepiece.FocalLength
    
