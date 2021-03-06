﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ImageLibrary
{
    /// <summary>
    /// Common Image Functionality
    /// </summary>
    /// <typeparam name="Y">Struct that represents a value in the image</typeparam>
    public interface IImage<Y> : ICollection, ICollection<Y>, IReadOnlyList<Y>, IDisposable
        where Y : struct, IEquatable<Y>
    {
        /// <summary>
        /// Columns (Width)
        /// </summary>
        int Cols { get; }

        /// <summary>
        /// Rows (Height)
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// Height (Rows)
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Width (Columns)
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Length = Width * Height
        /// </summary>
        int Length { get; }
        
        /// <summary>
        /// Internal Only - Mileage will vary
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Y[] Data { get; }

        /// <summary>
        /// Creates a copy of the existing image
        /// </summary>
        /// <returns>Copy of Existing Image</returns>
        IImage<Y> Copy();

        /// <summary>
        /// Creates new cropped image
        /// </summary>
        /// <param name="rect">Crop Rectangle</param>
        /// <returns>Cropped Image</returns>
        IImage<Y> Crop(System.Drawing.Rectangle rect);

        /// <summary>
        /// Creates new cropped image
        /// </summary>
        /// <param name="x1">starting x location</param>
        /// <param name="y1">starting y location</param>
        /// <param name="width">crop width</param>
        /// <param name="height">crop height</param>
        /// <returns>Cropped Image</returns>
        IImage<Y> Crop(int x1, int y1, int width, int height);

        /// <summary>
        /// Creates a new image which is padded
        /// </summary>
        /// <param name="width">New Width</param>
        /// <param name="height">New Height</param>
        /// <returns>Padded Image</returns>
        IImage<Y> Pad(int width, int height);

        /// <summary>
        /// Upsamples Rows and Columns
        /// </summary>
        /// <returns>New Upsample Image</returns>
        IImage<Y> Upsample();

        /// <summary>
        /// Usamples Columns Only
        /// </summary>
        /// <returns>New Upsampled (Horizontally) Image</returns>
        IImage<Y> UpsampleCols();

        /// <summary>
        /// Creates new image with upsamples rows (width)
        /// </summary>
        /// <returns>New Upsampled (Vertically) Image</returns>
        IImage<Y> UpsampleRows();
        
        /// <summary>
        /// Returns a new image which is downsampled
        /// </summary>
        /// <returns></returns>
        IImage<Y> Downsample();

        /// <summary>
        /// Returns a new image only horizontally downsampled
        /// </summary>
        /// <returns></returns>
        IImage<Y> DownsampleCols();

        /// <summary>
        /// Returns a new image only vertically downsamples
        /// </summary>
        /// <returns></returns>
        IImage<Y> DownsampleRows();

        /// <summary>
        /// Vertical Flip
        /// </summary>
        /// <returns></returns>
        IImage<Y> FlipX();

        /// <summary>
        /// Horizontal Flip
        /// </summary>
        /// <returns></returns>
        IImage<Y> FlipY();

        /// <summary>
        /// Horizontal and Vertical Flip
        /// </summary>
        /// <returns></returns>
        IImage<Y> FlipXY();

        /// <summary>
        /// Creates a new Transposed Image
        /// </summary>
        /// <returns>New Transposed Image</returns>
        IImage<Y> Transpose();

        /// <summary>
        /// 2D Location in the image
        /// </summary>
        /// <param name="i">Y location</param>
        /// <param name="j">X location</param>
        /// <returns>Pixel value at that location</returns>
        Y this[int i, int j] { get; set; }

        /// <summary>
        /// 1D Location in the image
        /// </summary>
        /// <param name="index">Value between 0 and Width * Height - 1</param>
        /// <returns>Pixel value at that location</returns>
        new Y this[int index] { get; set; }

        /// <summary>
        /// Tell the pixel color representation at location i, for every location in image
        /// </summary>
        /// <param name="iRgba">Action that is called for every location i</param>
        void ToIndexedBgra(Action<int, BGRA> iRgba);

        /// <summary>
        /// Returns image as RGB byte array
        /// </summary>
        /// <returns></returns>
        byte[] ToBGR();

        /// <summary>
        /// Returns image as RGBA byte array
        /// </summary>
        /// <returns></returns>
        byte[] ToBGRA();

        /// <summary>
        /// Returns image as a PixelColor struct array
        /// </summary>
        /// <returns></returns>
        BGRA[] ToPixelColor();
    }
}