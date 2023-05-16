import React, { useState } from 'react';

function Customers() {
  const [file, setFile] = useState(null);

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
    } else {
      console.log('File upload failed');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input type="file" onChange={(e) => setFile(e.target.files[0])} required />
      <button type="submit">Upload</button>
    </form>
  );
}

export default Customers;
