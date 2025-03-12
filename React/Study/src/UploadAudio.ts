import { useState } from "react";
import axios from "axios";

export default function UploadAudio() {
  const [selectedFile, setSelectedFile] = useState(null);
  const [uploadSuccess, setUploadSuccess] = useState(false);
  const [errorMessage, setErrorMessage] = useState("");

  const handleFileChange = (event) => {
    setSelectedFile(event.target.files[0]);
    setUploadSuccess(false);
    setErrorMessage("");
  };

  const handleUpload = async () => {
    if (!selectedFile) return;

    const formData = new FormData();
    formData.append("file", selectedFile);

    try {
      await axios.post("http://localhost:5000/api/upload", formData, {
        headers: { "Content-Type": "multipart/form-data" },
      });
      setUploadSuccess(true);
    } catch (error) {
      setErrorMessage("שגיאה בהעלאת הקובץ");
      console.error("Upload Error:", error);
    }
  };

  return (
    <>
      <div className="upload-container">
        <h2>העלאת קובץ שמע</h2>
        <input type="file" onChange={handleFileChange} accept="audio/*" />
        <button onClick={handleUpload} disabled={!selectedFile}>
          העלה
        </button>
        {uploadSuccess && <p className="success-msg">✔️ הקובץ הועלה בהצלחה!</p>}
        {errorMessage && <p className="error-msg">{errorMessage}</p>}
      </div>
    </>
  );
    
}
