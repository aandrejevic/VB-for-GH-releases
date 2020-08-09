  Validate input
    If (B Is Nothing) Then Return

    'We'll iterate over all the faces and simultaneously remember the lowest and highest so far.
    Dim lowPoint As Double = Double.MaxValue
    Dim highPoint As Double = Double.MinValue

    For Each face As BrepFace In B.Faces
      'Convert the Face to a new Brep.
      Dim faceBrep As Brep = face.DuplicateFace(True)

      'Compute the Area Mass Properties of the brep
      Dim ap As AreaMassProperties = AreaMassProperties.Compute(faceBrep)

      'If the Area centroid is a new low, assign the brep to the lowest output.
      If (ap.Centroid.Z < lowPoint) Then
        lowPoint = ap.Centroid.Z
        lowest = faceBrep
      End If

      'If the Area centroid is a new high, assign the brep to the highest output.
      If (ap.Centroid.Z > highPoint) Then
        highPoint = ap.Centroid.Z
        highest = faceBrep
      End If
    Next
