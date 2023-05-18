import React, { useState, useEffect } from 'react';

function Customers() {
  const [file, setFile] = useState(null);
  const [files, setFiles] = useState([]);

  const handleSubmit = async (event) => {
    event.preventDefault();

    const formData = new FormData();
    formData.append('file', file);

    const response = await fetch('/api/customers/upload', {
      method: 'POST',
      body: formData,
    });

    if (response.ok) {
      console.log('File uploaded successfully');
      await fetchFiles(); // Refresh the file list after a successful upload
    } else {
      console.log('File upload failed');
    }
  };

  const fetchFiles = async () => {
    const response = await fetch('/api/customers/list');
    const fileNames = await response.json();
    setFiles(fileNames);
  };

  useEffect(() => {
    fetchFiles();
  }, []);

  const handleDownload = async (filename) => {
    const response = await fetch(`/api/customers/download?filename=${filename}`);
    const blob = await response.blob();
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = filename;
    link.click();
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input type="file" onChange={(e) => setFile(e.target.files[0])} required />
        <button type="submit">Upload</button>
      </form>
      
      <ul>
        {files.map((file) => (
          <li key={file}>
            {file} <button onClick={() => handleDownload(file)}>Download</button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Customers;
