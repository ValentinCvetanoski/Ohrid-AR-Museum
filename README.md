🏛️ Ohrid AR Museum

Ohrid AR Museum is a mobile application that uses augmented reality (AR) to bring the city’s history to life. By overlaying historical photos onto real-world locations, users can explore how landmarks have evolved over time directly through their phone.

✨ Features
📍 GPS-Based AR Triggers – View content when near real landmarks
🖼️ Historical Photo Overlay – Compare past vs present in AR
🎚️ Opacity Slider – Adjust visibility of historical images
📖 Information Panel – Learn about each location
🧭 Plane Detection – Anchors AR content realistically
📦 JSON Database – Dynamic loading of locations and assets

🛠️ Tech Stack
Unity (2022 LTS)
C#
AR Foundation + ARCore
GPS / Location Services
JSON for data storage

⚙️ How It Works
App initializes AR and GPS services
Loads landmark data from a JSON file
Tracks user location in real time
When user enters a landmark radius, AR content appears
User interacts with the overlay (opacity, info panel)

📁 Project Structure
Assets/
  ├── Scripts/
  │     ├── LocationManager.cs
  │     ├── ARPhotoController.cs
  ├── Resources/
  │     ├── locations.json
  │     ├── Images/
  
🚀 Future Improvements
🎧 Audio narration
🌍 Multi-language support
📷 Photo sharing
📡 Offline mode
🧱 3D historical reconstructions

📌 Purpose
This project aims to preserve and showcase Ohrid’s cultural heritage through interactive AR, creating an engaging and educational experience for tourists and locals.

📄 License
GNU v3 License
