import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { ItemListPage } from './pages/ItemListPage'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<ItemListPage />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
