namespace Equipment

open System

[<Measure>] type mm
[<Measure>] type inch
[<Measure>] type degree

type Manufacturer = Manufacturer of string
type Design = Design of string
type FocalLength = FocalLength of float<mm>
type EyeRelief = EyeRelief of float<mm>
type FieldStop = FieldStop of float<mm>
type BarrelDiameter = BarrelDiamer of float<inch>
type ApparentFieldOfView = ApparentFieldOfView of int<degree>

type Eyepiece = {
    Id: Guid
    Manufacturer: Manufacturer
    Design: Design
    FocalLength: FocalLength
    EyeRelief: EyeRelief
    BarrelDiameter: BarrelDiameter
    ApparentFieldOfView: ApparentFieldOfView
}

//module Eyepiece =
//    let calculateSomething  =
//        let ep = Eyepiece {
//            Id = Guid.NewGuid();
//            Manufacturer = Manufacturer "TeleVue";
//            Design = Design "Plossl";
//            FocalLength = FocalLength 9<mm>;
//            EyeRelief = EyeRelief 20<mm>;
//            BarrelDiameter = BarrelDiameter 2.0<inch>;
//            ApparentFieldOfView = ApparentFieldOfView 72<degree>
//        }

    
