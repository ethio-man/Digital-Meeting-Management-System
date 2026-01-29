
param(
    [string]$SourceFile,
    [string]$DestinationFile
)

Add-Type -AssemblyName System.Drawing

$img = [System.Drawing.Image]::FromFile($SourceFile)
$size = 256
$resized = new-object System.Drawing.Bitmap($size, $size)
$graph = [System.Drawing.Graphics]::FromImage($resized)
$graph.InterpolationMode = [System.Drawing.Drawing2D.InterpolationMode]::HighQualityBicubic
$graph.DrawImage($img, 0, 0, $size, $size)

$ms = New-Object System.IO.MemoryStream
$resized.Save($ms, [System.Drawing.Imaging.ImageFormat]::Png)
$pngBytes = $ms.ToArray()

# ICO Header
# Reserved (2), Type (2), Count (2)
$header = [byte[]]@(0, 0, 1, 0, 1, 0)

# Entry
# Width (1), Height (1), Palette (1), Reserved (1)
# Planes (2), BPP (2)
# Size (4)
# Offset (4)

$width = 0 # 0 means 256
$height = 0 # 0 means 256
$palette = 0
$reserved = 0
$planes = 1
$bpp = 32
$sizeBytes = [BitConverter]::GetBytes([int]$pngBytes.Length)
$offset = [BitConverter]::GetBytes([int](6 + 16))

$entry = [byte[]]@($width, $height, $palette, $reserved, 0, 0, 0, 0) # Planes/BPP placeholder
[System.Buffer]::BlockCopy([BitConverter]::GetBytes([int16]$planes), 0, $entry, 4, 2)
[System.Buffer]::BlockCopy([BitConverter]::GetBytes([int16]$bpp), 0, $entry, 6, 2)
$entry += $sizeBytes + $offset

# Write
$fs = [System.IO.File]::Create($DestinationFile)
$fs.Write($header, 0, $header.Length)
$fs.Write($entry, 0, $entry.Length)
$fs.Write($pngBytes, 0, $pngBytes.Length)
$fs.Close()

$img.Dispose()
$resized.Dispose()
$graph.Dispose()
$ms.Dispose()

Write-Host "Converted $SourceFile to $DestinationFile"
