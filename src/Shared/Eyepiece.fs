module Equipment

open System

[<Measure>] type mm
[<Measure>] type degree
[<Measure>] type kg

type Manufacturer = Manufacturer of string
type Design = Design of string
type FocalLength = FocalLength of float<mm>
type EyeRelief = EyeRelief of float<mm>
type FieldStop = FieldStop of float<mm>
type BarrelDiameter = BarrelDiameter of float<mm>
type ApparentFieldOfView = ApparentFieldOfView of int<degree>
type Aperture = Aperture of float<mm>
type Weight = Weight of float<kg>

type Eyepiece = {
    Id: Guid
    Manufacturer: Manufacturer
    Design: Design
    FocalLength: FocalLength
    EyeRelief: EyeRelief
    BarrelDiameter: BarrelDiameter
    ApparentFieldOfView: ApparentFieldOfView
}

type Telescope =  {
    id: Guid
    Manufacturer: Manufacturer
    Design: Design
    FocalLength: FocalLength
    EyeRelief: EyeRelief
    Aperture: Aperture
    OTAWeight: Weight
}
//{
//       Id = Guid.NewGuid();
//       Manufacturer = Manufacturer "TeleVue";
//       Design = Design "Plossl";
//       FocalLength = FocalLength 9.0<mm>;
//       EyeRelief = EyeRelief 20.0<mm>;
//       BarrelDiameter = BarrelDiameter 2.0<inch>;
//       ApparentFieldOfView = ApparentFieldOfView 72<degree>
//   }
let magnification (telescope: Telescope) (eyepiece: Eyepiece) : float =
    telescope.FocalLength /  eyepiece.FocalLength
    
