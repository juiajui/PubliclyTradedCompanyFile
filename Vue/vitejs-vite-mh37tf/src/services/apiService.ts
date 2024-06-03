// src/services/apiService.ts
import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://localhost:7282/api/ListedCompany',
  headers: {
    'Content-Type': 'application/json'
  }
});

export default {
  async getListedCompanyRevenue() {
    const response = await apiClient.post('/GetListedCompanyRevenue',{coNo:null});
    return response.data;
  }
};