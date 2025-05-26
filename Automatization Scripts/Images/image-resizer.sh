#!/bin/bash

# Set the desired width for the resized images - e.g. 30% means that its 30% of its original size
percent=30
#DONT FORGET TO CHANGE the SRC and DEST fol

# Set the source directory where original images are located
src_dir="/Users/paulobala/Downloads/wetransfer_naturezamagica_2023-11-26_1202/Desenhos"

# Set the destination directory where resized images will be saved
dest_dir="/Users/paulobala/Downloads/wetransfer_naturezamagica_2023-11-26_1202/Desenhos_30percent"

# Find all PNG files in the source directory and its subdirectories
find "$src_dir" -type f -name "*.png" | while read -r file; do
    # Get the relative path of the file (stripping the source directory path)
    relative_path="${file#$src_dir}"

    # Create the destination directory structure
    dest_path="$dest_dir$relative_path"
    mkdir -p "$(dirname "$dest_path")"

    # Resize the image and save it to the destination directory
    convert "$file" -resize "${percent}%" "$dest_path"
    echo "Resized: $file -> $dest_path"
done

# Find all PNG files in the source directory and its subdirectories
find "$src_dir" -type f -name "*.PNG" | while read -r file; do
    # Get the relative path of the file (stripping the source directory path)
    relative_path="${file#$src_dir}"

    # Create the destination directory structure
    dest_path="$dest_dir$relative_path"
    mkdir -p "$(dirname "$dest_path")"

    # Resize the image and save it to the destination directory
    convert "$file" -resize "${percent}%" "$dest_path"
    echo "Resized: $file -> $dest_path"
done

echo "Image resizing completed!"
